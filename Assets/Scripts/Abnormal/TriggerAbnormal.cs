using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class TriggerAbnormal : AbnormalObject
{
    [SerializeField]private AbnormalType _abnormalType;
    [SerializeField]private List<FunctionSO> functions = new List<FunctionSO>();
    [SerializeField] private Transform abnormalTarget = null;
    private int index = 0;
    [SerializeField]private bool once = true;
    private bool triggered = false;
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
        if (once)
        {
            if (!triggered)
            {
                triggered = true;
                if (other.CompareTag("Player"))
                {
                    if (abnormalTarget is null)
                        functions[index].Execute(transform);
                    else
                    {
                        functions[index].Execute(abnormalTarget);
                    }
                }
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                if (abnormalTarget is null)
                    functions[index].Execute(transform);
                else
                {
                    functions[index].Execute(abnormalTarget);
                }
            }
        }
        
        
        
    }
}
