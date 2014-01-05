using UnityEngine;
using System.Collections;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public float fireDelay;
    
    private bool fired = false;
    private float currentTime;
    private float fireTime;
    
    void Update()
    {
        if (fired && (fireTime += Time.deltaTime) > fireDelay / 2) {
            fireTime = 0;
            transform.Translate(new Vector2(.1f, 0));
            fired = false;
        }
        
        if ((currentTime += Time.deltaTime) > fireDelay) {
            currentTime = 0;
            Instantiate(bullet, transform.position + new Vector3(renderer.bounds.size.x, 0, 0), transform.rotation * GetAccuracyRotation());
            audio.Play();
            transform.Translate(new Vector2(-.1f, 0));
            fired = true;
        }
    }
    
    Quaternion GetAccuracyRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(-2, 2));
    }
}