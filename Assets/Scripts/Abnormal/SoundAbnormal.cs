using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAbnormal : AbnormalObject
{
    [SerializeField]private List<string> sfxNames = new List<string>();
    [SerializeField]private AbnormalType abnormalType;
    private int _id = 0;
    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType type = (AbnormalType)message.Mid;

        if (type == abnormalType)
        {
            _id = UnityEngine.Random.Range(1, sfxNames.Count);
        }
    }

    public string GetSfxName()
    {
        return sfxNames[_id];
    }
}
