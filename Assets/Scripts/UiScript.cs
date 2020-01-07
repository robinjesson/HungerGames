using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour
{
    public static GameObject life_bg;
    public static GameObject life_bd;
    public static GameObject life_hg;
    public static GameObject life_hd;
    private static bool isDeaD;
    public static int life;

    private DateTime lauchDeadLine;
    private DateTime lauchWinLine;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Mort").SetActive(false);
        life_bd = GameObject.Find("Vie_bd");
        life_bg = GameObject.Find("Vie_bg");
        life_hd = GameObject.Find("Vie_hd");
        life_hg = GameObject.Find("Vie_hg");
        life = 4;
        isDeaD = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeaD)
        {
            activeCanvasWonDead();
        }
    }

    public void DeleteLife()
    {
        life--;
        if(life == 3)
        {
            Destroy(life_bd);
            Debug.Log("test1");
        } 
        else if(life == 2)
        {
            Destroy(life_bg);
            Debug.Log("test2");
        }
        else if (life == 1)
        {
            Destroy(life_hg);
            Debug.Log("test3");
        }
        else if (life == 0)
        {
            Destroy(life_hd);
            Debug.Log("test4");

            this.lauchDeadLine = DateTime.Now;
            isDeaD = true;

        }
        else
        {
            life = 4;
            Debug.Log("mort, reset");
        }

    }

    private void activeCanvasWonDead()
    {
        Debug.Log(GameObject.Find("Mort"));
        foreach (Transform child in gameObject.transform)
        {
            if(child.name == "Vie")
            {
                child.gameObject.SetActive(false);
            }
            else if (child.name == "Mort")
            {
                child.gameObject.SetActive(true);
            }
        }

        if(this.lauchDeadLine!=null)
            if(this.lauchDeadLine.AddSeconds(3)<=DateTime.Now)
            {
                SceneManager.LoadScene("Menu");
            }
    }

    public void showVictory()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "Vie")
            {
                child.gameObject.SetActive(false);
            }
            else if (child.name == "Victoire")
            {
                child.gameObject.SetActive(true);
            }
        }

        if (this.lauchWinLine != null)
            if (this.lauchWinLine.AddSeconds(3) <= DateTime.Now)
            {
                SceneManager.LoadScene("Menu");
            }
    }

    public void initLaunchWInLine()
    {
        this.lauchWinLine = DateTime.Now;
    }
}
