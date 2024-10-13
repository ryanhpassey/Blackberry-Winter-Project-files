using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hebe_MoveState : Hebe_ParentState
{
    private Vector2 _hebeMove;
    private float _moveSpeed;
    private bool _attackPressed = false;
    private bool _dashPressed = false;

    private Rigidbody2D _rb;
    private Animator _animator;


    // Called on Start(). Used to get references to components
    public override void StateStart(Player_StateMachine PreviousState)
    {
        _rb = PreviousState.rb;
        _moveSpeed = PreviousState.HebeStats.Speed;
        _animator = PreviousState.animator;
    }

    public override void EnterPlayerState(Player_StateMachine PreviousState)
    {
        _attackPressed = false;
        _dashPressed = false;
        _animator.Play("Hebe_Moving");
    }

    // Is called every Update()
    public override void UpdatePlayerState(Player_StateMachine currentState)
    {
        if(_attackPressed)
        {
            currentState.ChangePlayerState(currentState._attackState);
        }
        else if(_dashPressed)
        {
            currentState.ChangePlayerState(currentState._dashState);
        }
        else
        {
            //Move, but floor the input first
            _hebeMove = FloorInputValues(currentState.hebeMoveVector);
        }
        ToggleMoveAnimation();
    }

    // Is called every FixedUpdate()
    public override void FixedUpdatePlayerState(Player_StateMachine currentState){
        _rb.MovePosition(_rb.position + _hebeMove * _moveSpeed * Time.fixedDeltaTime);
    }

    public override void StateExit(Player_StateMachine currentState)
    {
        StopMovingAnimation();
    }

    public override void OnDash()
    {
        _dashPressed = true;
    }

    public override void OnAttack()
    {
        _attackPressed = true;
    }

    // Sets the animation to "idle"
    private void StopMovingAnimation()
    {
        _animator.SetBool("IsMoving", false);
    }


    // Toggle animation based on the direction player is facing
    private void ToggleMoveAnimation() 
    {
        if (_hebeMove == Vector2.zero)
        {
            StopMovingAnimation();
        }
        else 
        {
            _animator.SetBool("IsMoving", true);
            _animator.SetFloat("xMovement", _hebeMove.x);
            _animator.SetFloat("yMovement", _hebeMove.y);
        }
    }

    // Any input values below .25 are set to 0.
    private Vector2 FloorInputValues(Vector2 playerInput)
    {
        if (Math.Abs(playerInput.x) < .25)
        {
            playerInput.x = 0;
        }
        if (Math.Abs(playerInput.y) < .25)
        {
            playerInput.y = 0;
        }
        return playerInput;
    }
    
}
