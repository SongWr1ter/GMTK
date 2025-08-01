using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "EmptyData", menuName = "AbnormalData/EmptyData")]
public class AbnormalData : ScriptableObject
{
    public enum AbnormalDataTypes
    {
        Sprite,
        Function,
        String,
    }
    
    public AbnormalDataTypes Type;
    
}
