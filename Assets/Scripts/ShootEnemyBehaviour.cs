using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyBehaviour : MonoBehaviour
{
    private DateTime lastOccurence;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        lastOccurence = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now >= lastOccurence.AddSeconds(3))
        {
            lastOccurence = DateTime.Now;
            Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
