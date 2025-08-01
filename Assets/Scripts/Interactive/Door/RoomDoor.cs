using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor :AbnormalObject,Interactive
{
    private string _audioName = "";
    [SerializeField]private AbnormalType _abnormalType;
    [SerializeField]private List<string> audioNames = new List<string>();
    [SerializeField] private GameObject _interactButton;
    public void OnInteract()
    {
        if (_audioName != "")
            SoundManager.PlayAudio(_audioName);
    }

    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType abnormalType = (AbnormalType)message.Mid;
        if (_abnormalType == abnormalType)
        {
            _audioName = audioNames[1];
        }
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