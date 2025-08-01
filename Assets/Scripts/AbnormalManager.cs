using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbnormalType
{
    None,
    Player_Move_Abnormal,
}
public class AbnormalManager : MonoBehaviour
{
    //维护一个所有异常事件表:id,描述
    
    //负责选择某个异常
    
    //给所有有AbnormalObject接口的物体发送信号
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessage();
        }
    }

    private void SendMessage()
    {
        MessageCenter.SendMessage(new CommonMessage()
        {
            Mid = SelectAbnormal(),
        },MESSAGE_TYPE.ABNORMAL);
    }
    
    private int SelectAbnormal()
    {
        return (int)AbnormalType.Player_Move_Abnormal;
    }
}
