using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hebe_AttackState : Hebe_ParentState
{
    private Animator _HebeAnimator, _AttackAnimator;

    private Transform _attackPivot;
    private LayerMask _enemyLayer;
    private int _attackPower;
    private bool _isAttackPressed, _isDashPressed, _isUsingJab;
    private int _actionable = 0;
    private FacingDirection _playerDirection;



    public override void StateStart(Player_StateMachine PreviousState)
    {
        _HebeAnimator = PreviousState.animator;
        _AttackAnimator = PreviousState.attackAnimator;
        _attackPivot = PreviousState.attackPivot;
        _enemyLayer = LayerMask.GetMask("Enemies");
        _attackPower = PreviousState.HebeStats.Attack;
    }

    public override void EnterPlayerState(Player_StateMachine PreviousState)
    {
        _actionable = 0;
        _isUsingJab = false;
        _isAttackPressed = false;
        _isDashPressed = false;
        _playerDirection = PreviousState._hebeDirection;
        SelectAttack(PreviousState.attackSelection);
    }

    public override void StateExit(Player_StateMachine PreviousState)
    {
        _actionable = 0;
    }

    // Spawn a hitbox and call the TakeDamage function on all hit enemies
    public override void OnAttack()
    {
        _isAttackPressed = true;
    }

    public override void OnDash()
    {
        _isDashPressed = true;
    }

    // Rotates our attackPivot to align with the direction we're facing.
    private void RotateAttack(FacingDirection attackDirection)
    {
        switch (attackDirection)
        {
            case FacingDirection.Up:
                _attackPivot.rotation = Quaternion.Euler(new Vector3(0,0,0));
                _HebeAnimator.Play("Hebe_Attack_Up");
                break;
            case FacingDirection.UpRight:
                _attackPivot.rotation = Quaternion.Euler(new Vector3(0,0,-45));
                _HebeAnimator.Play("Hebe_Attack_UpRight");
                break;
            case FacingDirection.Right:
                _attackPivot.rotation = Quaternion.Euler(new Vector3(0,0,-90));
                _HebeAnimator.Play("Hebe_Attack_Right");
                break;
            case FacingDirection.DownRight:
                _attackPivot.rotation = Quaternion.Euler(new Vector3(0,0,-135));
                _HebeAnimator.Play("Hebe_Attack_DownRight");
                break;
            case FacingDirection.Down:
                _attackPivot.rotation = Quaternion.Euler(new Vector3(0,0,180));
                _HebeAnimator.Play("Hebe_Attack_Down");
                break;
            case FacingDirection.DownLeft:
                _attackPivot.rotation = Quaternion.Euler(new Vector3(0,0,135));
                _HebeAnimator.Play("Hebe_Attack_DownLeft");
                break;
            case FacingDirection.Left:
                _attackPivot.rotation = Quaternion.Euler(new Vector3(0,0,90));
                _HebeAnimator.Play("Hebe_Attack_Left");
                break;
            case FacingDirection.UpLeft:
                _attackPivot.rotation = Quaternion.Euler(new Vector3(0,0,45));
                _HebeAnimator.Play("Hebe_Attack_UpLeft");
                break; 
        }
    }

    private void StateEnd(Player_StateMachine PreviousState)
    {
        if (_isAttackPressed)
            PreviousState.ChangePlayerState(PreviousState._attackState);
        else    
            PreviousState.ChangePlayerState(PreviousState._movementState);
    }

    // default attack option
    private void JabAttack(){
        // just rotate the hitbox then play the animation
        RotateAttack(_playerDirection);
        _AttackAnimator.Play("JabAnimation");
        _isUsingJab = true;
    }

    // not technically an attack, but fits here
    // called when Hebe is standing in a trigger tagged "Freeze" for too long
    private void FrozenState(){
        _HebeAnimator.Play("Hebe_Frozen");
    }

    private void SelectAttack(int choice){
        switch (choice){
            case 9:
                FrozenState();
                break;
            default:
                JabAttack();
                break;
        }
    }

    // called at the end of an animation by the state machine
    public override void MakeActionable(Player_StateMachine PreviousState)
    {
        if(_isUsingJab && _actionable < 1) {
            if (_isDashPressed)
                PreviousState.ChangePlayerState(PreviousState._dashState);
            _actionable += 1;
        }
        else{
            StateEnd(PreviousState);
        }
    }
}
