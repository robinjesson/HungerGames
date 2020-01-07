using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCameraBehaviour : MonoBehaviour
{
    public float speed = 10.0f;

    private DateTime creationTime;
    private Vector3 forward;
    
    /// <summary>
    /// Initialise la date de création de la balle.
    /// Intitailise le vecteur de direction constant de la balle.
    /// </summary>
    void Start()
    {
        creationTime = DateTime.Now;
        forward = Camera.main.transform.forward.normalized*1.0f;
    }
    
    /// <summary>
    /// Avance dans une direction droite.
    /// Se détruit au bout de 20 secondes.
    /// </summary>
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
