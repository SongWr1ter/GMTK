using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbnormal : AbnormalObject
{
    public List<FunctionSO> functions = new List<FunctionSO>();

    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType type = (AbnormalType)message.Mid;

        if (type == AbnormalType.Player_Move_Abnormal)
        {
            functions[1].Execute(this.transform);
        }
    }
}
