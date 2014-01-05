using UnityEngine;
using System.Collections;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet; // our bullet
    public float fireDelay;   // how long between shots
    
    private bool fired = false;
    private float currentTime;
    private float fireTime;
    
    void Update()
    {
        // if time to fire...
        if ((currentTime += Time.deltaTime) > fireDelay) {
            currentTime = 0;
            // create bullet
            Instantiate(bullet, transform.position + new Vector3(renderer.bounds.size.x, 0, 0), transform.rotation * GetAccuracyRotation());
            // play firing audio
            audio.Play();
            // kickback the gun
            transform.Translate(new Vector2(-.1f, 0));
            fired = true;
        }
        
        Kickback();
    }
    
    // if we've kickbacked half of fireDelay, reset gun back to original position
    void Kickback()
    {
        if (fired && (fireTime += Time.deltaTime) > fireDelay / 2) {
            fireTime = 0;
            transform.Translate(new Vector2(.1f, 0));
            fired = false;
        }
    }
    
    Quaternion GetAccuracyRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(-2, 2));
    }
}