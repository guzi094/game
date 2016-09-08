using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public int hp = 3;   
    public int point = 100;
    Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () {
        spaceship = GetComponent<Spaceship>();
        Move(transform.up * -1);
        
        if(spaceship.canShot == false)
        {
            yield break;
        }

        while(true)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);
                spaceship.Shot(shotPosition);
            }

            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    public void Move(Vector2 direction)
    {                      
        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        if (layerName != "Bullet(Player)") return;

        Transform playerBulletTransform = c.transform.parent;

        Bullet bullet = playerBulletTransform.GetComponent<Bullet>();        

        hp -= bullet.power;
        
        Destroy(c.gameObject);

        // ヒットポイントが0以下であれば
        if (hp <= 0)
        {
            FindObjectOfType<Score>().AddPoint(point);

            // 爆発
            spaceship.Explosion();

            // エネミーの削除
            Destroy(gameObject);
        }
        else
        {
            spaceship.GetAnimator().SetTrigger("Damage");
        }
    }
}