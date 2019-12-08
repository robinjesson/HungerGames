using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    public static GameObject life_bg;
    public static GameObject life_bd;
    public static GameObject life_hg;
    public static GameObject life_hd;
    public static GameObject life_text;
    public static int life;

    // Start is called before the first frame update
    void Start()
    {
        life_bd = GameObject.Find("Vie_bd");
        life_bg = GameObject.Find("Vie_bg");
        life_hd = GameObject.Find("Vie_hd");
        life_hg = GameObject.Find("Vie_hg");
        life_text = GameObject.Find("Life_text");
        life = 4;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void DeleteLife()
    {
        life--;
        if(life == 3)
        {
            Destroy(life_bd);
            life_text.GetComponent<UnityEngine.UI.Text>().text = "3";
            Debug.Log("test1");
        } 
        else if(life == 2)
        {
            Destroy(life_bg);
            life_text.GetComponent<UnityEngine.UI.Text>().text = "2";
            Debug.Log("test2");
        }
        else if (life == 1)
        {
            Destroy(life_hg);
            life_text.GetComponent<UnityEngine.UI.Text>().text = "1";
            Debug.Log("test3");
        }
        else if (life == 0)
        {
            Destroy(life_hd);
            life_text.GetComponent<UnityEngine.UI.Text>().text = "0";
            Debug.Log("test4");
        }
        else
        {
            life = 4;
            Debug.Log("mort, reset");
        }

    }
}
