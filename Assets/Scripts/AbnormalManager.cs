using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbnormalType
{
    None = 0,
    Player_Move_Abnormal = 1,
    Billboard_Text_Abnormal,
    Smoke_Sign_Follow_Abnormal,
    Drinker_Red_Abnormal,
    Window_RedHand_Abnormal,
    Door_Red_Abnormal,
    Clock_Reverse_Abnormal,
    Fan_Red_Abnormal,
    Mirror_Abnormal,
    Billboard_Photo_Abnormal,
    Bed_Stack_Abnormal,
    Evelator_Sound_Abnormal,
    Room_InteractSound_Abnormal,
}
public class AbnormalManager
{
    //维护一个所有异常事件表:id,描述
    //负责选择某个异常
    private const float AbnormalProbability = 0.5f; //异常发生概率
    public AbnormalManager()
    {
        
    }
    
    public AbnormalType SelectAbnormal()
    {
        float randomValue = UnityEngine.Random.value;
        if (randomValue < AbnormalProbability)
        {
            //触发异常
            //从AbnormalType中随机选择一个异常
            Array values = Enum.GetValues(typeof(AbnormalType));
            AbnormalType randomAbnormal = (AbnormalType)values.GetValue(UnityEngine.Random.Range(1, values.Length));
            //返回异常类型
            return randomAbnormal;
        }
        else
        {
            //没有异常
            return AbnormalType.None;
        }
        
    }
}
