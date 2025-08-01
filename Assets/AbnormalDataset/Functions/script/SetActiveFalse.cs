using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SetActiveFalse", menuName = "FunctionSO/SetActiveFalse")]
public class SetActiveFalse : FunctionSO
{
    public bool value;
    public override void Execute(Transform transform)
    {
        transform.gameObject.SetActive(value);
    }
}
