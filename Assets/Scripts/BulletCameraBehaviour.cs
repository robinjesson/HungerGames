using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCameraBehaviour : MonoBehaviour
{
    public float speed = 1.0f;

    private DateTime creationTime;

    // Start is called before the first frame update
    void Start()
    {
        creationTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        GetComponent<Rigidbody>().AddForce(transform.forward * step);
    }
}
