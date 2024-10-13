using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hebe_DeadState : Hebe_ParentState
{
    Animator _animator;
    Collider2D collider;

    public override void StateStart(Player_StateMachine PreviousState){
        _animator = PreviousState.animator;
        collider = PreviousState.PlayerCollider;
    }

    public override void EnterPlayerState(Player_StateMachine PreviousState){
        _animator.Play("Hebe_Death");
        collider.enabled = false;
    }

    public override void UpdatePlayerState(Player_StateMachine Hebe){}
}
