using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BillboardAbnormal : AbnormalObject
{
    [Header("异常组")]
    [SerializeField] private List<CanvasGroup> texts = new List<CanvasGroup>();
    [Header("正常组")]
    [SerializeField] private List<CanvasGroup> ntexts = new List<CanvasGroup>();
    [SerializeField] private AbnormalType billboardAbnormalType;

    protected override void Awake()
    {
        base.Awake();
        int id = UnityEngine.Random.Range(0, ntexts.Count);
        for (int i = 0; i < ntexts.Count; i++)
        {
            if (i != id)
            {
                ntexts[i].alpha = 0;
            }
            else
            {
                ntexts[i].alpha = 1;
            }
        }
    }

    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType type = (AbnormalType)message.Mid;

        if (type == billboardAbnormalType)
        {
            //从[1,texts.Count]随机选一个数字
            int abi = UnityEngine.Random.Range(0, texts.Count);
            for (int i = 0; i < texts.Count; i++)
            {
                if (i != abi)
                {
                    texts[i].alpha = 0;
                }
                else
                {
                    texts[i].alpha = 1;
                }
            }
            for (int i = 0; i < ntexts.Count; i++)
            {
                ntexts[i].alpha = 0;
            }
        }
    }
}
