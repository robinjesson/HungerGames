using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFallowCam : MonoBehaviour
{

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        this.cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(cam.transform.position.x, this.cam.transform.position.y, this.cam.transform.position.z+1);
        this.transform.rotation = this.cam.transform.rotation;
    }
}
