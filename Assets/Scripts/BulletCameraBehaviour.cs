using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCameraBehaviour : MonoBehaviour
{
    public float speed = 10.0f;

    private DateTime creationTime;
    private Vector3 forward;
    
    void Start()
    {
        creationTime = DateTime.Now;
        forward = Camera.main.transform.forward.normalized*1.0f;
    }
    
    void Update()
    {
        transform.position += forward * Time.deltaTime;

        if (DateTime.Now >= creationTime.AddSeconds(20))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetType().ToString());
    }


}
