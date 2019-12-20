using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyBehaviour : UiScript
{
    public float speed = 1.0f;

    private float x;
    private float y;
    private float z;
    private DateTime creationTime;
    private Vector3 movementVector;
  
    // Start is called before the first frame update
    void Start()
    {
        Vector3 target = Camera.main.transform.position;
        movementVector = (target - transform.position).normalized;
        creationTime = DateTime.Now;
   
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementVector * Time.deltaTime * speed;
        
        if (DateTime.Now >= creationTime.AddSeconds(20))
        {
            Destroy(gameObject);
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Main Camera")
        {
            Debug.Log("touché");
            GameObject.Find("Canvas vie").GetComponent<UiScript>().DeleteLife();
        }
    }


}
