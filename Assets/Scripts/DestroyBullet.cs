using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public float destroyDelay;
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

   
}
