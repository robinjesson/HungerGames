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
    }

    public void OnInputUp(InputEventData eventData)
    {
        this.transform.localScale = this.defaultScale;
        this.tmp.text = this.defaultText;
        Application.LoadLevel("SampleScene");
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
