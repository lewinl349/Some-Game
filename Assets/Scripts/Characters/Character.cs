using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] private float baseSpeed = 10.0f;
    [SerializeField] private float maxHP = 100.0f;
    [SerializeField] private float baseDEF = 30.0f;
    [SerializeField] private float baseATK = 15.0f;

    [Header("Dynamic Stats")]
    [SerializeField] private float currentHP;

    public float GetSpeed() { return baseSpeed; }

    public float GetMaxHP() { return maxHP; }

    public float GetCurrentHP() { return currentHP; }

    public float GetBaseDEF() { return baseDEF; }

    public float GetBaseATK() { return baseATK; }

    private void Awake()
    {
        SetupStats();
    }

    private void SetupStats()
    {
        currentHP = maxHP;
    }

    public virtual void Attack()
    {
        Debug.Log("Default Attack");
    }

    public virtual void Ability()
    {
        Debug.Log("Default Ability");
    }
}
