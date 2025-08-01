using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbnormalText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       var type = GameManager.Instance.GetCurrentAbnormalType();
       //把type转换为对应的文本描述
         string abnormalText = type switch
         {
              AbnormalType.Player_Move_Abnormal => "Player Move Abnormal",
              AbnormalType.Smoke_Sign_Follow_Abnormal => "Smoke Sign Follow Abnormal",
              AbnormalType.Billboard_Text_Abnormal => "Billboard Text Abnormal",
              _ => "Safe or Unknown Abnormal"
         };

       GetComponent<TMP_Text>().text = abnormalText;
    }


}
