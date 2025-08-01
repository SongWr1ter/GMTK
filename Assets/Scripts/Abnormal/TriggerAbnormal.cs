using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class TriggerAbnormal : AbnormalObject
{
    [SerializeField]private AbnormalType _abnormalType;
    [SerializeField]private List<FunctionSO> functions = new List<FunctionSO>();
    private int index = 0;
    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType abnormalType = (AbnormalType)message.Mid;
        if (_abnormalType == abnormalType)
        {
            index = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        functions[index].Execute(transform);
    }
}
