using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HebeHP : MonoBehaviour, IDamageable
{
    // HPStats is a scriptable object housing stats. The slider is UI
    public HPStats stats;
    public Slider HPBar;

    // delegate is used by other classes, such as the Blink Red animation
    public delegate void Damaged();
    public delegate void Revive();
    public static event Revive OnRevive;
    public static event Damaged OnDamaged;

    // Be sure Hebe is at full HP at the start
    void Start()
    {
        stats.CurrentHP = stats.MaxHP;
    }

    // When taking damage, update stats then update UI
    public void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);
        HPBar.value = stats.CurrentHP;
        OnDamaged?.Invoke();

        if (stats.CurrentHP <= 0)
        {
            OnRevive?.Invoke();
            if (stats.CurrentHP <= 0){
                // game over
            }
        }
    }

    public void HealDamage(int damage)
    {
        stats.HealDamage(damage);
        HPBar.value = stats.CurrentHP;
    }
    
}
