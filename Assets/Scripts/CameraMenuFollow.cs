using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comportement permettant que le menu d'accueil reste orienté et face à la caméra.
/// </summary>
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
    
    void Start()
    {
        this.pos1 = this.transform.position;
        this.rot1 = this.transform.rotation;
        this.menuRotator.transform.position = this.transform.position;
        this.easyGO.transform.position = new Vector3(pos1.x - 0.45f, pos1.y, pos1.z + 1);
        this.mediumGO.transform.position = new Vector3(pos1.x, pos1.y, pos1.z + 1);
        this.hardGO.transform.position = new Vector3(pos1.x + 0.45f, pos1.y, pos1.z + 1);
    }

    /// <summary>
    /// Replace le menu face à la caméra.
    /// </summary>
    void Update()
    {
        this.menuRotator.transform.position = this.transform.position;
        
 
        if (NeedRotation())
        {
            menuRotator.transform.rotation = this.transform.rotation;

        }
            
    }

    /// <summary>
    /// Pour savoir si une rotation des boutons est nécessaire lorsque la caméra est trop éloignée.
    /// </summary>
    /// <returns>boolean</returns>
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
