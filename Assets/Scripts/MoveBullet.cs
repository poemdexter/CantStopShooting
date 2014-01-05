using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour
{
    public GameObject impact;
    public float speed;
    private float killTime;
    
    void Start()
    {
        rigidbody2D.velocity = Vector2.right * speed;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Surface")) {
            Instantiate(impact, collision.contacts[0].point, transform.rotation);
            Destroy(gameObject);
        }
    }
}