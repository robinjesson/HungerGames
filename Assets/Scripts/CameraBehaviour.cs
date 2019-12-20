﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject cameraBulletPrefab;
    public GameObject enemyPrefab;
    public int nbEnemies = 1;
    public int radius = 1;

    private GestureRecognizer gr;
    private int enemyLeft;

    void Start()
    {
        this.enemyLeft = nbEnemies;
        double angle = 2 * Math.PI / nbEnemies;
        for(int i = 0; i < nbEnemies; i++)
        {
            float x = (float) Math.Cos(i * angle);
            float y = this.transform.position.y-this.transform.position.y;
            float z = (float) Math.Sin(i * angle);

            Vector3 pos = new Vector3(x, y, z);
            pos *= radius;
            var e = Instantiate(enemyPrefab, pos, Quaternion.identity);
            e.transform.LookAt(this.transform.position);
            Debug.Log(pos);
        }

        gr = new GestureRecognizer();
        gr.Tapped += this.Gr_Tapped;
        gr.SetRecognizableGestures(GestureSettings.Tap);
        gr.StartCapturingGestures();
    }

    private void Gr_Tapped(TappedEventArgs obj)
    {
        Instantiate(cameraBulletPrefab, this.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (enemyLeft <= 0)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.name == "Canvas vie")
                {
                    child.gameObject.GetComponent<UiScript>().showVictory();
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(cameraBulletPrefab, this.transform.position, Quaternion.identity);
        }
    }

    public void enemyKilled()
    {
        this.enemyLeft--;
        if (enemyLeft <= 0)
        {
            GameObject.Find("Canvas vie").GetComponent<UiScript>().initLaunchWInLine();
        }
    }


}
