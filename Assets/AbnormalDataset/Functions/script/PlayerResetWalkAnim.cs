using UnityEngine;

[CreateAssetMenu(fileName = "PlayerResetWalkAnim", menuName = "FunctionSO/PlayerFunction/PlayerResetWalkAnim")]
public class PlayerResetWalkAnim : FunctionSO
{
    public override void Execute(Transform transform)
    {
        transform.GetComponent<Animator>().SetBool("Abnormal", false);
    }
}