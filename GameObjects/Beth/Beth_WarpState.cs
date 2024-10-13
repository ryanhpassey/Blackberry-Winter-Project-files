using System;
using UnityEngine;

public class Beth_WarpState : Beth_ParentState
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _transform, _playerPosition;

    private Transform _warpPoint1;
    private Transform _warpPoint2;
    private Transform _warpPoint3;
    private Vector2 _warpPointPlayer;

    private System.Random _rnd = new System.Random();
    // the animation has 2 "end" triggers, only end the animation if this bool is true.
    private bool _animationTrigger;

    // Get necessary references
    public override void StateStart(Beth_StateMachine Beth)
    {
        _animator = Beth.animator;
        _rb = Beth.rb;
        _transform = Beth.transform;
        _playerPosition = Beth._playerPosition;

        _warpPoint1 = Beth._warpPoint1;
        _warpPoint2 = Beth._warpPoint2;
        _warpPoint3 = Beth._warpPoint3;
    }

    public override void EnterState(Beth_StateMachine Beth)
    {
        _animationTrigger = false;
        _animator.Play("BethWarp");
    }

    // "OnAnimationEnd" is called twice in the animation. Once when Beth dissapears signaling a warp,
    // and the other at the actual end of the animation. I used a bool to keep track of which call we're on.
    public override void OnAnimationEnd(Beth_StateMachine Beth)
    {
        // first call
        if (!_animationTrigger){
            _animationTrigger = true;
            _warpPointPlayer = _playerPosition.position;
            WarpPostion();
        }
        // second call
        else{
            Beth.ChangeState(Beth._attackState);
        }
    }

    // Move Beth's transform to a random designated location
    private void WarpPostion(){
        switch (_rnd.Next(3)){
            case 0:
                _transform.position = _warpPoint1.position;
                break;
            case 1:
                _transform.position = _warpPoint2.position;
                break;
            case 2:
                _transform.position = _warpPoint3.position;
                break;
            default:
                _transform.position = _warpPointPlayer;
                break;
        }
    }
}
