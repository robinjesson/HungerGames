using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private DateTime lastShoot;
    private double intervalShoot;
    private DateTime lastMove;
    private double intervalMove;

    public GameObject bulletPrefab;
    
    void Start()
    {
        this.intervalShoot = UnityEngine.Random.Range(3, 10);
        this.intervalMove = UnityEngine.Random.Range(3, 10);
        this.lastShoot = DateTime.Now;
        this.lastMove = DateTime.Now;
    }
    
    void Update()
    {
        this.Shoot();
        this.MovesToCam();
    }

    void Shoot()
    {
        if (DateTime.Now >= lastShoot.AddSeconds(this.intervalShoot))
        {
            var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            this.lastShoot = DateTime.Now;
        }
    }

    void MovesToCam()
    {
        if(DateTime.Now >= lastMove.AddSeconds(this.intervalMove))
        {
            Vector3 camPos = Camera.main.transform.position;
            Vector3 movementVector = (camPos - this.transform.position).normalized;
            this.transform.position += movementVector;
            this.lastMove = DateTime.Now;
        }
    }


}
