using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour,Interactive
{
    [SerializeField]private UIBillBoard _uiBillBoard;
    [SerializeField]private GameObject _interactButton;
    public void OnInteract()
    {
        _uiBillBoard.Show(true);
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
