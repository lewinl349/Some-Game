using UnityEngine;

public class RegularAttack : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] private float cooldown = 1.0f;

    protected Character character;

    private void Awake()
    {
        character = GetComponentInParent<Character>();
    }

    public virtual void DealDamage(GameObject target)
    {
        Debug.Log("Dealt Damage!");
    }
}
