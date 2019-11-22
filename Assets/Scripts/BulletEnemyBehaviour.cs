using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyBehaviour : MonoBehaviour
{
    private float speed = 7.0f;

    private float x;
    private float y;
    private float z;
    private DateTime creationTime;
    private bool mustContinue;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 target = Camera.main.transform.position;
        x = target.x;
        y = target.y;
        z = target.z;
        creationTime = DateTime.Now;
        mustContinue = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(x, y, z);
        float step = speed * Time.deltaTime;
        if(mustContinue == false)
        {
            this.transform.LookAt(target);
            this.transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else{
            this.transform.position += this.transform.forward * speed * Time.deltaTime;
            if(DateTime.Now >= creationTime.AddSeconds(20))
            {
                Destroy(gameObject);
            }
        }
        if (this.transform.position == target && target != Camera.main.transform.position)
        {
            mustContinue = true;          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera")
        {
            Destroy(gameObject);
        }
    }
}

