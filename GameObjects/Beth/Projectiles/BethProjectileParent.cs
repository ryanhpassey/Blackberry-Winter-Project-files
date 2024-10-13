using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BethProjectileParent : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private Transform thisPosition, PlayerPosition, SpawnPosition;
    private Vector2 targetDirection;
    [SerializeField] private float Speed = 5;
    [SerializeField] private Rigidbody2D rb;
    protected string startAnimation = "";
    protected string destroyedAnimation = "";

    private void FixedUpdate(){
        rb.MovePosition(rb.position + targetDirection * Speed * Time.fixedDeltaTime);
    }

    protected virtual void OnEnable() {
        // Spawn on the snowman
        thisPosition.position = SpawnPosition.position;
        Shoot(); // defaults to straight
        Animator.Play(startAnimation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col){
        if (col.tag != "Enemy" && col.tag != "Freeze"){
            // # play destroy animation
            gameObject.SetActive(false);
        }
    }

    protected virtual void Shoot(){
        // Shoot straight by default
        // Set the direction the snowball is heading. Also normalize the magnitude to 1
        targetDirection = (PlayerPosition.position - thisPosition.position).normalized * Speed;
    }
}

