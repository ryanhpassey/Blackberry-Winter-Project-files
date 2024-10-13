using System;
using UnityEngine;

public class Hebe_dashState : Hebe_ParentState
{
    private Rigidbody2D _rb;
    private Animator _animator;

    private bool _dashPressed, _superDash = false;
    private float _dashSpeed;
    private Vector2 _dashDirection;


    public override void StateStart(Player_StateMachine PreviousState)
    {
        _rb = PreviousState.rb;
        _animator = PreviousState.animator;
    }

    public override void EnterPlayerState(Player_StateMachine PreviousState)
    {

        _dashPressed = false;
        _dashDirection = TransformRotater.Aim(PreviousState._hebeDirection);
        PlayDashAnimation();
    }

    private void PlayDashAnimation(){
        if (!_superDash){
            _dashSpeed = 25;
            _animator.Play("DashPlaceholder");
        }
        else{
            _dashSpeed = 40;
            _animator.Play("SuperDash");
            _superDash = false;
        }
    }

    // Is called every FixedUpdate()
    public override void FixedUpdatePlayerState(Player_StateMachine currentState)
    {
        _rb.MovePosition(_rb.position + _dashDirection * _dashSpeed * Time.fixedDeltaTime);
    }

    public void OnDash(FacingDirection hebeDirection)
    {
        _dashPressed = true;
    }

    public override void MakeActionable(Player_StateMachine PreviousState)
    {
        if(_dashPressed){
            EnterPlayerState(PreviousState);
        }
        else{
            PreviousState.ChangePlayerState(PreviousState._movementState);
        }
    }

    public void SetSuperDash(){
        _superDash = true;
    }
}

