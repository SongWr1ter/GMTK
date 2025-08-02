using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAbnormal : AbnormalObject
{
    [SerializeField]private AbnormalType _abnormalType = AbnormalType.Window_RedHand_Abnormal;
    [SerializeField] private List<string> dialogues = new List<string>();
    [SerializeField]private List<string> audioIngNames = new List<string>();
    [SerializeField]private List<string> audioAfterNames = new List<string>();
    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType abnormalType = (AbnormalType)message.Mid;
        if (abnormalType == _abnormalType)
        {
            var w = GetComponent<Window>();
            w.SetShowText(dialogues[1]);
            w.SetAudioing(audioIngNames[1]);
            w.SetAudioAfter(audioAfterNames[1]);
        }
    }
}
