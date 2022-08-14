using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehavior : MonoBehaviour
{
    Vector3 camOffset = new Vector3(0f, 2f, -4f);

    private Transform target;



    private void Start()
    {
        target = GameObject.Find("Player").transform;

    }
    private void LateUpdate()
    {
        transform.position = target.TransformPoint(camOffset);
        transform.LookAt(target);
    }
}
