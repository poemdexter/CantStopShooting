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
        LookAtMouseCursor();
        
        // if time to fire...
        if ((currentTime += Time.deltaTime) > fireDelay) {
            currentTime = 0;
            // create bullet at end of gun
            Instantiate(bullet, transform.position + (transform.right * renderer.bounds.size.x), transform.rotation); //* GetAccuracyRotation());
            // play firing audio
            audio.Play();
            // kickback the gun
            transform.Translate(-Vector2.right * .1f);
            fired = true;
        }
        
        Kickback();
    }
    
    // always have gun point at mouse
    void LookAtMouseCursor()
    {
        // get world position of mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // bump out Z so that it's more accurate for some reason
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, -100);
        // make gun look at mouse
        transform.rotation = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        // reset x and y rotation so that we can see gun
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);
    }
    
    // if we've kickbacked half of fireDelay, reset gun back to original position
    void Kickback()
    {
        if (fired && (fireTime += Time.deltaTime) > fireDelay / 2) {
            fireTime = 0;
            transform.Translate(Vector2.right * .1f);
            fired = false;
        }
    }
    
    Quaternion GetAccuracyRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(-2, 2));
    }
}