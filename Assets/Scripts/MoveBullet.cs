using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    
    private float killTime;
    
    void Update()
    {
        transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
        
        if ((killTime += Time.deltaTime) > 1.0f)
            Destroy(gameObject);
    }
}