using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour
{
    public GameObject impact; // impact animation object
    public float speed;       // velocity of bullet
    
    void Start()
    {
        // move bullet
        rigidbody2D.velocity = transform.right * speed;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // if collide with surface, create impact object at point of contact
        if (collision.collider.CompareTag("Surface")) {
            Instantiate(impact, collision.contacts[0].point, transform.rotation);
            Destroy(gameObject);
        }
    }
}