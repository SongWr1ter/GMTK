using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAbnormal : AbnormalObject
{
    [SerializeField] private List<string> dialogues = new List<string>();
    
    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType abnormalType = (AbnormalType)message.Mid;
        if (abnormalType == AbnormalType.Smoke_Sign_Follow_Abnormal)
        {
            GetComponent<Window>().SetShowText(dialogues[1]);
        }
    }
}
