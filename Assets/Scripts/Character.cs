using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10.0f;
    public float hp = 100.0f;

    public virtual void Attack()
    {
        Debug.Log("Default Attack");
    }

    public virtual void Ability()
    {
        Debug.Log("Default Ability");
    }
}
