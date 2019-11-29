using System.Collections;
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

    void Start()
    {
        double angle = 2 * Math.PI / nbEnemies;
        for(int i = 0; i < nbEnemies; i++)
        {
            float x = (float) Math.Cos(i * angle);
            float y = this.transform.position.y;
            float z = (float) Math.Sin(i * angle);

            Vector3 pos = new Vector3(x, y, z);
            pos *= radius;
            Instantiate(enemyPrefab, pos, Quaternion.identity);
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

    
}
