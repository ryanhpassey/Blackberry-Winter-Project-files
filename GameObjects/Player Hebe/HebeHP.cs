using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HebeHP : MonoBehaviour, IDamageable
{
    // HPStats is a scriptable object housing stats. The slider is UI
    [SerializeField] private HPStats stats;
    [SerializeField] private Slider HPBar;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D hebeHurtbox;
    [SerializeField] private float hitStopSeconds = .05f;
    [SerializeField] private float intangibilitySeconds = .6f;

    // delegate is used by other classes, such as the Blink Red animation
    public delegate void Damaged();
    public delegate void Revive();
    public delegate void PlayerDeath();
    //public delegate void PlayerDeath();
    public static event Revive OnRevive;
    public static event Damaged OnDamaged;
    public static event PlayerDeath OnPlayerDeath;
    //public static event PlayerDeath OnPlayerDeath;


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

        if (stats.CurrentHP <= 0){
            OnRevive?.Invoke();
            if (stats.CurrentHP <= 0){
                OnPlayerDeath.Invoke(); 
            }
        }
        else{
            StartCoroutine(DisableHurtbox(hebeHurtbox, intangibilitySeconds));
        }
    }

    public void HealDamage(int damage)
    {
        stats.HealDamage(damage);
        HPBar.value = stats.CurrentHP;
    }

    private IEnumerator DisableHurtbox(Collider2D hurtbox, float seconds){
        hurtbox.enabled = false;
        yield return new WaitForSeconds(seconds);
        hurtbox.enabled = true;
    }
    
}
