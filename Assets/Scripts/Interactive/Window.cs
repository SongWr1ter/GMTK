using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour,Interactive
{
    [SerializeField]private UIDialogue dialogue;
    [SerializeField]private GameObject _interactButton;
    [SerializeField,TextArea]private string showText = "玻璃后面静悄悄的。";
    [SerializeField] private string audio_ing = "KickDoor";
    [SerializeField] private string audio_after = "KickDoor";
    public void SetShowText(string text)
    {
        showText = text;
    }

    public void SetAudioing(string text)
    {
        audio_ing = text;
    }

    public void SetAudioAfter(string text)
    {
        audio_after = text;
    }
    public void OnInteract()
    {
        //Play Audio interacting
        HideInteract();
        if (audio_ing != "") SoundManager.PlayAudio(audio_ing);
        dialogue.Show(true,showText);
        StartCoroutine(AudioAfter());
    }

    IEnumerator AudioAfter()
    {
        yield return new WaitForSeconds(0.5f);
        if (audio_after != "") SoundManager.PlayAudio(audio_after);
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
