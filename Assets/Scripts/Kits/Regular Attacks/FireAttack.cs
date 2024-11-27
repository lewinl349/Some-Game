using UnityEngine;

public class FireAttack : RegularAttack
{
    [Header("Special Stats")]
    [SerializeField] private float mainDMGMultiplier = 0.50f;

    public override void DealDamage(GameObject target)
    {
        float atk = character.GetBaseATK();
        float dmg = atk * mainDMGMultiplier;

        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDMG(dmg);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DealDamage(other.gameObject);
        }
    }
}
