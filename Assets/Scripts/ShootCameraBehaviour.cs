using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class ShootCameraBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;

    private GestureRecognizer gr;
    // Start is called before the first frame update
    void Start()
    {
        gr = new GestureRecognizer();
        gr.Tapped += this.Gr_Tapped;
        gr.SetRecognizableGestures(GestureSettings.Tap);
        gr.StartCapturingGestures();
    }

    private void Gr_Tapped(TappedEventArgs obj)
    {
        Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
    }

    
}
