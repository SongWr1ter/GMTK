using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour,Interactive
{
    [SerializeField]private UIDialogue dialogue;
    [SerializeField]private GameObject _interactButton;
    [SerializeField,TextArea]private string showText = "玻璃后面静悄悄的。";
    public void SetShowText(string text)
    {
        showText = text;
    }
    public void OnInteract()
    {
        dialogue.Show(true,showText);
    }
    
    public void ExitInteract()
    {
        dialogue.Show(false);
    }

    public void HideInteract()
    {
        _interactButton.SetActive(false);
    }

    public void ShowInteract()
    {
        _interactButton.SetActive(true);
    }
}
