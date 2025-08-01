using UnityEngine;

[CreateAssetMenu(fileName = "EmptyFunction", menuName = "FunctionSO/EmptyFunction")]
public class FunctionSO : ScriptableObject
{
    public virtual void Execute(Transform transform)
    {
    }
}
