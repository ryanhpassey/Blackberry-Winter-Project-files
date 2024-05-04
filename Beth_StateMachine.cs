using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beth_StateMachine : MonoBehaviour
{
    // Unity references
    public Rigidbody2D rb;
    public Animator animator;
    public Transform bethTransform;

    public Beth_ParentState _currentState;
    public Beth_MoveState _movementState = new Beth_MoveState();
    public Beth_AttackState _attackState = new Beth_AttackState();

    public LocationProjector _playerLocation;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        bethTransform = gameObject.GetComponent<Transform>();

        _movementState.StateStart(this);
        _attackState.StateStart(this);

        _currentState = _movementState;
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
}
