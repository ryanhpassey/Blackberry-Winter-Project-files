using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beth_AttackState : Beth_ParentState
{
    private Animator _animator;
    private Transform _transform;

    private System.Random _rnd = new System.Random();

    // I instantiate rand here. I use this to decide which attack to pick,
    // but also to track which attack I used last time.
    private int rand = 0;

    // Get necesary references
    public override void StateStart(Beth_StateMachine Beth)
    {
        _animator = Beth.animator;
        _transform = Beth.transform;
    }

    public override void EnterState(Beth_StateMachine Beth)
    {
        PickAttack();
    }

    // when done attacking, decide what to do
    public override void OnAnimationEnd(Beth_StateMachine Beth)
    {
        // 1 in 5 chance to warp after attacking
        if (_rnd.Next(5) == 0){
            Beth.ChangeState(Beth._warpState);
        }
        else{
            // If player is close, attack again. Or else move
            if (IsCloseToPlayer(Beth._playerPosition.position))
                Beth.ChangeState(Beth._attackState);
            else
                Beth.ChangeState(Beth._movementState);
            }
        // If player is close, attack again. Or else move
    }

    // Checks distance to provided Vector 2 location
    private bool IsCloseToPlayer(Vector2 playerLocation)
    {
        if (Vector2.Distance(_transform.position, playerLocation) > 3f)
            return false;
        else
            return true;
    }

    // choose an attack randomly
    private void PickAttack()
    {
        int lastRand = rand;
        do {
            rand = Random.Range(0,7);
        }
        while (lastRand == rand);
        switch (rand){
            case 0:
                _animator.Play("BethSwipeAttack");
                break;
            case 1:
                _animator.Play("BethGroundSlam");
                break;
            case 2:
                _animator.Play("BethIceBallSpawn");
                break;
            case 3:
                _animator.Play("BethSnowflakeSpawn");
                break;
            case 4:
                _animator.Play("BethIceBreath");
                break;
            default:
                _animator.Play("BethSnowmanSpawn");
                break;
        }
    }
}
