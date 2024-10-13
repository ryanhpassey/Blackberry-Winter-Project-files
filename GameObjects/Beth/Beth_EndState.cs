using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beth_EndState : Beth_ParentState
{
    Animator _animator;
    Collider2D _collider;
    public bool _bethDeath = false;

    public override void StateStart(Beth_StateMachine Beth){
        _animator = Beth.animator;
        _collider = Beth.bethCollider;
    }

    public override void EnterState(Beth_StateMachine Beth)
    {
        if (_bethDeath){
            // play death animation
        }
        else{
            _animator.Play("BethVictory");
        }
        _collider.enabled = false;
    }
}
