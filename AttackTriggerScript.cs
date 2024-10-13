using UnityEngine;
using System.Collections;

public class AttackTriggerScript : MonoBehaviour
{
    public CharacterStats stats;
    public Animator animator;

    // made static so hitstop length is universal
    public static float hitStopSeconds = .05f;

    // objects can ignore hitstop by ommiting the animator reference in Unity
    private IEnumerator HitStop(Animator animation)
    {
        animation.speed = 0f;
        yield return new WaitForSeconds(hitStopSeconds);
        animation.speed = 1f;
    }

    protected void DealDamage(Collider2D enemy){
        enemy.GetComponent<IDamageable>()?.TakeDamage(stats.Attack);
        if (animator != null)
        {
            StartCoroutine(HitStop(animator));
        }
        Debug.Log(gameObject + " hit " + enemy);
    }

    protected virtual void OnTriggerEnter2D(Collider2D enemy)
    {
        DealDamage(enemy);
    }
}
