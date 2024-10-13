using UnityEngine;

public class BethAttackTriggerScript : AttackTriggerScript
{

    protected override void OnTriggerEnter2D(Collider2D enemy)
    {
        // Don't deal damage to self
        if (enemy.gameObject.tag == "Player"){
            DealDamage(enemy);
        }
    }
}
