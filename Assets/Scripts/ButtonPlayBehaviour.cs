using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayBehaviour : MonoBehaviour, IMixedRealityInputHandler
{
    public string defaultText = "Button";

    private Vector3 defaultScale;
    private TextMeshPro tmp;

    /// <summary>
    /// Réduit l'épaisseur du bouton pendant le clique.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputDown(InputEventData eventData)
    {
        this.transform.localScale = new Vector3(this.defaultScale.x, this.defaultScale.y, 0.01f);
        this.tmp.text = "Pressed";
        Debug.Log("ondown");
    }

    /// <summary>
    /// Lorsque le clique est relaché, le nombre d'ennemies est déterminé avec la difficulté choisie,
    /// puis lance le jeu.
    /// </summary>
    /// <param name="eventData"></param>
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
        
        SceneManager.LoadScene("SampleScene");
        Debug.Log("onup");
    }

    /// <summary>
    /// Donne le texte choisi au bouton.
    /// </summary>
    void Start()
    {
        this.defaultScale = this.transform.localScale;
        this.tmp = this.transform.GetChild(0).GetComponent<TextMeshPro>();
        this.tmp.text = this.defaultText;
    }
}
