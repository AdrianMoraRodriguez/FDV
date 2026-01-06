using UnityEngine;

public class AnimatorMirror : MonoBehaviour
{
    [Header("Animators")]
    public Animator sourceAnimator;
    public Animator targetAnimator;

    [Header("Parameters")]
    public string isWalkingParam = "IsWalking";
    public string isJumpingParam = "IsJumping";

    void Update()
    {
        if (sourceAnimator == null || targetAnimator == null)
            return;

        targetAnimator.SetBool(
            isWalkingParam,
            sourceAnimator.GetBool(isWalkingParam)
        );

        targetAnimator.SetBool(
            isJumpingParam,
            sourceAnimator.GetBool(isJumpingParam)
        );
    }
}
