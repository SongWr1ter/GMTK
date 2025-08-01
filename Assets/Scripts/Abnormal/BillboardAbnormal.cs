using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BillboardAbnormal : AbnormalObject
{
    [SerializeField] private List<CanvasGroup> texts = new List<CanvasGroup>();
    [SerializeField] private AbnormalType billboardAbnormalType;
    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType type = (AbnormalType)message.Mid;

        if (type == billboardAbnormalType)
        {
            for (int i = 0; i < texts.Count; i++)
            {
                if (i != 1)
                {
                    texts[i].alpha = 0;
                }
                else
                {
                    texts[i].alpha = 1;
                }
            }
        }
    }
}
