using UnityEngine;

public class HebeAttackScript : AttackTriggerScript
{
    public delegate void DamageDealt();
    public static event DamageDealt OnDamageDealt;

    protected override void OnTriggerEnter2D(Collider2D enemy)
    {
        // OnDamageDealt is used by Radish to increase the radish counter
        if (enemy.gameObject.tag == "Enemy"){
            DealDamage(enemy);
            OnDamageDealt?.Invoke();
        }
    }
}
