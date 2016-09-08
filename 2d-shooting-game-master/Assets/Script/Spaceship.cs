using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

    public float speed;
    public float shotDelay;
    public GameObject bullet;
    public GameObject explosion;
    public bool canShot;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }  

    public Animator GetAnimator()
    {
        return animator;
    }
}
