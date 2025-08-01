using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbnormalLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.HasAbnormal)
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            GetComponent<Image>().color = Color.green;
        }
        
    }

   
}
