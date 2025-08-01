using System;
using UnityEngine;

public class AbnormalObject : MonoBehaviour
{
    protected virtual void Awake()
    {
        MessageCenter.AddListener(Abnormalize,MESSAGE_TYPE.ABNORMAL);
    }

    protected virtual void OnDestroy()
    {
        MessageCenter.RemoveListener(Abnormalize,MESSAGE_TYPE.ABNORMAL);
    }

    protected virtual void Abnormalize(CommonMessage message) { }
}
