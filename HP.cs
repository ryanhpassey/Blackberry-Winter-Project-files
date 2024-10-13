using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour, IDamageable
{
    public HPStats stats;
    public Slider HPBar;

    void Start()
    {
        stats.CurrentHP = stats.MaxHP;
    }

    public void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);
        HPBar.value = stats.CurrentHP;
    }

    public void HealDamage(int damage)
    {
        stats.HealDamage(damage);
        HPBar.value = stats.CurrentHP;
    }
    
}
