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

       GetComponent<TMP_Text>().text = type.ToString();
    }


}
