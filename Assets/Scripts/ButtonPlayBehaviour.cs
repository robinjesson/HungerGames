using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayBehaviour : MonoBehaviour, IMixedRealityInputHandler
{
    private TextMeshPro tmp;

    public string defaultText = "Button";
    private Vector3 defaultScale;
    public void OnInputDown(InputEventData eventData)
    {
        this.transform.localScale = new Vector3(this.defaultScale.x, this.defaultScale.y, 0.01f);
        this.tmp.text = "Pressed";
        Debug.Log("ondown");
    }

    public void OnInputUp(InputEventData eventData)
    {
        this.transform.localScale = this.defaultScale;
        this.tmp.text = this.defaultText;
        switch (this.defaultText)
        {
            case "Moyen":
                MenuNumbersEnemies.nbEnemies = 2;
                break;
            case "Difficile":
                MenuNumbersEnemies.nbEnemies = 3;
                break;
            default:
                MenuNumbersEnemies.nbEnemies = 1;
                break;
        }
        
        Application.LoadLevel("SampleScene");
        Debug.Log("onup");
    }

    // Start is called before the first frame update
    void Start()
    {
        this.defaultScale = this.transform.localScale;
        this.tmp = this.transform.GetChild(0).GetComponent<TextMeshPro>();
        this.tmp.text = this.defaultText;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
