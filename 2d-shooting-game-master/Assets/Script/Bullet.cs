using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 0.5f;
    // Use this for initialization

    public float lifeTime = 5;

    public int power = 1;

	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        Destroy(gameObject, lifeTime);
    }
	
	// Update is called once per frame
	void Update () {       
        
    }
}
