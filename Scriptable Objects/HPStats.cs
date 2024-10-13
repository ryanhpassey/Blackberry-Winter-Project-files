using UnityEngine;

[CreateAssetMenu]
public class HPStats : ScriptableObject
{
    public int MaxHP;
    public int CurrentHP;

    public void TakeDamage (int damage)
    {
        CurrentHP -= damage;
    }

    public void HealDamage(int damage)
    {
        CurrentHP += damage;
        // Ensure HP does not exceed max.
        if (CurrentHP > MaxHP) {
            CurrentHP = MaxHP;
        }
    }

}
