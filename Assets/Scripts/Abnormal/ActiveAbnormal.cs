using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbnormal : AbnormalObject
{
    [SerializeField]private AbnormalType _abnormalType;
    [SerializeField]private FunctionSO function;
    [SerializeField] private Transform abnormalTarget = null;
    protected override void Awake()
    {
        base.Awake();
        transform.gameObject.SetActive(false);
    }

    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType abnormalType = (AbnormalType)message.Mid;
        if (_abnormalType == abnormalType)
        {
            // Assuming the GameObject has a component that needs to be activated
            // For example, an Animator or a specific script
            if (function != null)
            {
                if (abnormalTarget is null)
                    function.Execute(transform);
                else
                {
                    function.Execute(abnormalTarget);
                }
            }
        }
    }
}
