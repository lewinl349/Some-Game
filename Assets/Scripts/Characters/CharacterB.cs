using System.Collections;
using UnityEngine;

public class CharacterB : Character
{
    [Header("Attacks")]
    [SerializeField] private GameObject fireAttack;

    private IEnumerator delayFunction;
    private float delay = 0.5f;

    public override void Attack()
    {
        if (!fireAttack.activeSelf)
        {
            fireAttack.SetActive(true);

            delayFunction = DeactivateDelay();
            StartCoroutine(delayFunction);
        }
    }

    private IEnumerator DeactivateDelay()
    {
        yield return new WaitForSeconds(delay);
        fireAttack.SetActive(false);
    }
}
