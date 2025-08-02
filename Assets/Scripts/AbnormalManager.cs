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
    Room_Number_Abnormal,
    Floor_Run_Abnormal,
}
public class AbnormalManager
{
    //维护一个所有异常事件表:id,描述
    //负责选择某个异常
    private const float AbnormalProbability = 0.85f; //异常发生概率
    //记录哪些异常已经被选取过了
    private Dictionary<AbnormalType, bool> abnormalDictionary = new Dictionary<AbnormalType, bool>();
    private int _abnormalLength = Enum.GetValues(typeof(AbnormalType)).Length;
    public AbnormalManager()
    {
        // Debug.Log(_abnormalLength);
        //将AbnormalType初始化abnormalDictionary
        for (int i = 1; i < _abnormalLength; i++)
        {
            abnormalDictionary.Add((AbnormalType)i, false);
        }
    }
    
    public AbnormalType SelectAbnormal()
    {
        float randomValue = UnityEngine.Random.value;
        if (randomValue < AbnormalProbability)
        {
            //触发异常
            //从AbnormalType中随机选择一个异常
            AbnormalType randomAbnormal = (AbnormalType)UnityEngine.Random.Range(1, _abnormalLength);
            // while (abnormalDictionary[randomAbnormal])
            // {
            //     randomAbnormal = (AbnormalType)UnityEngine.Random.Range(1, _abnormalLength);
            //     abnormalDictionary[randomAbnormal] = true;
            // }
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
