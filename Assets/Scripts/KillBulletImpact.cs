using UnityEngine;
using System.Collections;

public class KillBulletImpact : MonoBehaviour
{
    // used in animation event to kill impact object
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
