using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive2UI : MonoBehaviour,Interactive
{
    [SerializeField]private UIPop ui;
    [SerializeField]private GameObject _interactButton;
    public void OnInteract()
    {
        ui.Show(true);
    }
    
    public void ExitInteract()
    {
        ui.Show(false);
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
