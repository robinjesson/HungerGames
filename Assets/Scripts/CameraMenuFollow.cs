using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuFollow : MonoBehaviour
{

    public GameObject easyGO;
    public GameObject mediumGO;
    public GameObject hardGO;
    public GameObject menuRotator;

    private Vector3 pos1;
    private Vector3 pos2;
    private Quaternion rot1;
    private Quaternion rot2;

    // Start is called before the first frame update
    void Start()
    {
        pos1 = this.transform.position;
        rot1 = this.transform.rotation;
        menuRotator.transform.position = this.transform.position;
        easyGO.transform.position = new Vector3(pos1.x - 0.45f, pos1.y, pos1.z + 1);
        mediumGO.transform.position = new Vector3(pos1.x, pos1.y, pos1.z + 1);
        hardGO.transform.position = new Vector3(pos1.x + 0.45f, pos1.y, pos1.z + 1);
    }

    // Update is called once per frame
    void Update()
    {
        menuRotator.transform.position = this.transform.position;
        
 
        if (NeedRotation())
        {
            menuRotator.transform.rotation = this.transform.rotation;

        }
            
    }


    private bool NeedRotation()
    {
        rot2 = this.transform.rotation;
        if(Quaternion.Angle(rot1,rot2) > 40)
        {
            rot1 = rot2;
            return true;
        }
        else
        {
            return false;
        }
    }
}
