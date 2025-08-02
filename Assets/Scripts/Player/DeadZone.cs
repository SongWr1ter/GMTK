using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeadZone : MonoBehaviour
{
    private bool _flag = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
            
            if (other.CompareTag("Player") && !_flag)
            {
                _flag = true;
                GameManager.Instance.GameOver();
                other.GetComponent<Collider2D>().enabled = false;
                other.GetComponent<PlayerControl>().DeadAnim();
            }
        
    }
}
