using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour,Interactive
{
    [SerializeField] private bool AnswerIsAbnormalGate; // 是否有异常门
    
    [SerializeField]private GameObject _interactButton;
    public void OnInteract()
    {
        GameManager.Instance.NextScene(AnswerIsAbnormalGate);
    }
    
    public void ExitInteract()
    {
        
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
