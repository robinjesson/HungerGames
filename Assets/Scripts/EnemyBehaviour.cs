using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private DateTime lastOccurence;

    public GameObject bulletPrefab;
    public double intervalShoot=3;
    
    void Start()
    {
        lastOccurence = DateTime.Now;
    }
    
    void Update()
    {
        if (DateTime.Now >= lastOccurence.AddSeconds(intervalShoot))
        {
            var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            lastOccurence = DateTime.Now;
        }
    }
}
