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
  
    /// <summary>
    /// Cible la caméra.
    /// Initialise la direction de déplacement de la balle.
    /// Initialise la date de création de la balle.
    /// </summary>
    void Start()
    {
        Vector3 target = Camera.main.transform.position;
        movementVector = (target - transform.position).normalized;
        creationTime = DateTime.Now;
        this.transform.LookAt(Camera.main.transform);

    }

    /// <summary>
    /// Détruit l'objet après 20 secondes.
    /// Avance l'objet en ligne droite selon la direction initalisée.
    /// </summary>
    void Update()
    {
        transform.position += movementVector * Time.deltaTime * speed;
        
        if (DateTime.Now >= creationTime.AddSeconds(20))
        {
            Destroy(gameObject);
        }
     
    }

    /// <summary>
    /// Supprime une vie du joueur quand la balle heurte le joueur.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Main Camera")
        {
            Debug.Log("touché");
            GameObject.Find("Canvas vie").GetComponent<UiScript>().DeleteLife();
        }
    }


}
