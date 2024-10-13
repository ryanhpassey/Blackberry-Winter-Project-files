using System;
using UnityEngine;

public class Beth_MoveState : Beth_ParentState
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _transform, _playerPosition;

    private Transform _warpPoint1;
    private Transform _warpPoint2;
    private Transform _warpPoint3;

    private float _bethSpeed = 3;
    private System.Random _rnd = new System.Random();

    // Get necessary references
    public override void StateStart(Beth_StateMachine Beth)
    {
        _animator = Beth.animator;
        _rb = Beth.rb;
        _transform = Beth.transform;
        _playerPosition = Beth._playerPosition;
        _bethSpeed = Beth.bethStats.Speed;

        _warpPoint1 = Beth._warpPoint1;
        _warpPoint2 = Beth._warpPoint2;
        _warpPoint3 = Beth._warpPoint3;
    }

    public override void EnterState(Beth_StateMachine Beth)
    {
        _animator.Play("BethMoving");
    }

    public override void FixedUpdateState(Beth_StateMachine Beth)
    {
        // Move toward player
        _rb.position = Vector2.MoveTowards(_rb.position, _playerPosition.position, _bethSpeed * Time.fixedDeltaTime);
        // If player is close, then switch to attack state
        if (IsCloseToPlayer(_playerPosition.position))
            Beth.ChangeState(Beth._attackState);
    }

    // when done moving, attack
    public override void OnAnimationEnd(Beth_StateMachine Beth)
    {
        if (_rnd.Next(5) == 0){
            Beth.ChangeState(Beth._warpState);
        }
        else{
            Beth.ChangeState(Beth._attackState);
        }
    }

    // checks distance to provided Vector2 location
    private bool IsCloseToPlayer(Vector2 playerLocation)
    {
        if (Vector2.Distance(_transform.position, playerLocation) > 3f)
            return false;
        else
            return true;
    }

    
}
