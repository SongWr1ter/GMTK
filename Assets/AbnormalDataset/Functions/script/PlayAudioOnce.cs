using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayAudioOnce", menuName = "FunctionSO/PlayAudioOnce")]

public class PlayAudioOnce : FunctionSO
{
    public string AudioName;

    public override void Execute(Transform transform)
    {
        SoundManager.PlayAudio(AudioName);
    }
}
