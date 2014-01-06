using UnityEngine;
using System.Collections;

public class PlayerKnockback : MonoBehaviour
{
    public float power;
    private Transform gunTransform;
    
    void Start()
    {
        gunTransform = transform.GetChild(0);
    }
	
    void Update()
    {
        Vector3 pushVector = gunTransform.rotation * Vector3.left;
        rigidbody2D.AddForce(pushVector * power * Time.deltaTime);
    }
}
