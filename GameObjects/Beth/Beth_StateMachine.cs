using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beth_StateMachine : MonoBehaviour
{
    // Unity references
    public Rigidbody2D rb;
    public Animator animator;
    public Transform bethTransform, _playerPosition;
    public CharacterStats bethStats;
    public Collider2D bethCollider;

    public Beth_ParentState _currentState;
    public Beth_MoveState _movementState = new Beth_MoveState();
    public Beth_AttackState _attackState = new Beth_AttackState();
    public Beth_WarpState _warpState = new Beth_WarpState();
    public Beth_EndState _endState = new Beth_EndState();

    public Transform _warpPoint1;
    public Transform _warpPoint2;
    public Transform _warpPoint3;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        bethTransform = gameObject.GetComponent<Transform>();

        _movementState.StateStart(this);
        _attackState.StateStart(this);
        _endState.StateStart(this);
        _warpState.StateStart(this);

        _currentState = _movementState;
    }

    void OnEnable(){
        HebeHP.OnPlayerDeath += OnPlayerDeath;
    }

    void OnDisable(){
        HebeHP.OnPlayerDeath -= OnPlayerDeath;
    }

    void FixedUpdate()
    {
        // Call the current state's fixed update
        _currentState.FixedUpdateState(this);
    }

    // Change current state
    public void ChangeState(Beth_ParentState newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }

    // Called when Beth's animation is over
    public void OnAnimationEnd()
    {
        _currentState.OnAnimationEnd(this);
    }

    public void CallScreenShake(){
        StartCoroutine(ScreenShake.onShakeScreen());
    }

    public void OnPlayerDeath(){
        ChangeState(_endState);
    }
}
