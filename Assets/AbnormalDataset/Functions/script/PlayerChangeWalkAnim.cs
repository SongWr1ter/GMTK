using UnityEngine;

[CreateAssetMenu(fileName = "PlayerChangeWalkAnim", menuName = "FunctionSO/PlayerFunction/PlayerChangeWalkAnim")]
public class PlayerChangeWalkAnim : FunctionSO
{
    public override void Execute(Transform transform)
    {
        transform.GetComponent<Animator>().SetBool("Abnormal", true);
    }
}
