using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCameraBehaviour : MonoBehaviour
{
    public float speed = 10.0f;

    private DateTime creationTime;
    private Rigidbody rb;
    private Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
        creationTime = DateTime.Now;
        forward = Camera.main.transform.forward.normalized*1.0f;
    }

    // Update is called once per frame
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
