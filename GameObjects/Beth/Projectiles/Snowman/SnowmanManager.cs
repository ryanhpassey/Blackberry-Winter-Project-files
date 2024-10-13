using System;
using UnityEngine;

public class SnowmanManager : MonoBehaviour, IDamageable
{
    [SerializeField] private Animator SnowmanAnimator;
    [SerializeField] private GameObject Snowball;
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Transform SnowmanPosition;

    private void OnEnable(){
        SnowmanPosition.position = PlayerPosition.position;
        SnowmanAnimator.Play("SnowmanSpawn");
    }

    public void Attack(){
        SnowmanAnimator.Play("SnowmanAttack");
        Snowball.gameObject.SetActive(true);
    }

    public void Disable(){
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage){
        SnowmanAnimator.Play("SnowmanDestroy");
    }

    public void CheckSnowball(){
        if(Snowball.activeSelf){
            SnowmanAnimator.Play("SnowmanWait");
        }
        else{
            Attack();
        }
    }
}
