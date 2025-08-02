using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour,Interactive
{
    [SerializeField]private UIBillBoard _uiBillBoard;
    [SerializeField]private GameObject _interactButton;
    [SerializeField]private string sfxName;
    public void OnInteract()
    {
        SoundManager.PlayAudio(sfxName);
        _uiBillBoard.Show(true);
        HideInteract();
    }
    
    public void ExitInteract()
    {
        _uiBillBoard.Show(false);
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
