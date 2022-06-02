using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] float delayTimeForForcefield;
    [SerializeField] Animator forceAnimator;

    public void ForcefieldAttack()
    {
        forceAnimator.SetTrigger("Expand");

        StartCoroutine(TurnOfForcefield(delayTimeForForcefield));
    }

    IEnumerator TurnOfForcefield(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        forceAnimator.SetTrigger("ReturnIdle");
    }
}
