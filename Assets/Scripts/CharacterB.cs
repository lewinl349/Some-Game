using UnityEngine;

public class CharacterB : Character
{
    [Header("Attacks")]
    [SerializeField] private GameObject fireAttack;

    public override void Attack()
    {
        fireAttack.SetActive(true);
    }
}
