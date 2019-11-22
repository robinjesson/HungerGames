using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCameraBehaviour : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector3 target;
    private DateTime creationTime;
    private bool mustContinue;

    // Start is called before the first frame update
    void Start()
    {
        creationTime = DateTime.Now;
        target = Camera.main.transform.forward;
        mustContinue = false;
        this.transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (mustContinue == false)
        {
            this.transform.position += this.transform.forward * speed * Time.deltaTime; 
        }
        if (DateTime.Now >= creationTime.AddSeconds(20))
        {
            Destroy(gameObject);
        }
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Foe")
        {
            Destroy(gameObject);
        }

    }


}
