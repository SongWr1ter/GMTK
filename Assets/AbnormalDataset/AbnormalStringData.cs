using UnityEngine;

[CreateAssetMenu(fileName = "StringData", menuName = "AbnormalData/StringData")]
public class AbnormalStringData : AbnormalData
{
    public AbnormalDataTypes Type { get; } = AbnormalDataTypes.String;

    [TextArea]
    public string stringData;
    public string getStringData()
    {
        return stringData;
    }
}
