using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 1.0f;

    private float x;
    private float y;
    private float z;
    private DateTime creationTime;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 target = Camera.main.transform.position;
        x = target.x;
        y = target.y;
        z = target.z;
        creationTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(x, y, z);
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, target, step);

        if(DateTime.Now >= creationTime.AddSeconds(20))
        {
            Destroy(gameObject);
        }
    }
}
