using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum FacingDirection 
{
    Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft, Center
}

public class Player_StateMachine : MonoBehaviour
{
    // obvious references
    public Rigidbody2D rb;
    public Collider2D PlayerCollider;
    public Animator animator;
    public Animator attackAnimator;

    // Jab Point is the center of the hitbox cylinder
    public Transform jabPoint;
    // Attack pivot is the pivot for rotating the hitbox
    public Transform attackPivot;
    // Other script with methods for projectiles and the like
    public Attack_Projectile_Manager attackManager;

    // Store direction facing and vector headed
    public Vector2 hebeMoveVector;
    public FacingDirection _hebeDirection = FacingDirection.Right;

    // HebeStats houses her stats like speed. Location is location
    public CharacterStats HebeStats;

    // State used in state machine
    Hebe_ParentState _currentState;

    // Define each possible state for state machine
    public Hebe_MoveState _movementState = new Hebe_MoveState();
    public Hebe_AttackState _attackState = new Hebe_AttackState();
    public Hebe_dashState _dashState = new Hebe_dashState();
    public Hebe_DeadState _deadState = new Hebe_DeadState();
    
    // used in attack state. Passed in to indicate which attack is being used
    public int attackSelection;
    private int freezeLevel = 0;
    
    // Get references and call the StartState fuctions for our states
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();


        // make sure to end with Movement
        StateStart(_deadState);
        StateStart(_attackState);
        StateStart(_dashState);
        StateStart(_movementState);
    }

    void OnEnable(){
        HebeHP.OnPlayerDeath += OnPlayerDeath;
    }

    void OnDisable(){
        HebeHP.OnPlayerDeath -= OnPlayerDeath;
    }

    // call Update and FixedUpdate on our states
    void Update()
    {
        _currentState.UpdatePlayerState(this);
    }

    void FixedUpdate()
    {
        _currentState.FixedUpdatePlayerState(this);
        if (freezeLevel > 0){
            freezeLevel -= 1;
        }
    }

    // call StartState on the given state. Usually for getting references
    private void StateStart(Hebe_ParentState newState)
    {
        _currentState = newState;
        _currentState.StateStart(this);
    }

    public void ChangePlayerState(Hebe_ParentState newState)
    {
        _currentState.StateExit(this);
        _currentState = newState;
        _currentState.EnterPlayerState(this);
    }

    // Event - called with move input from controller
    void OnMove(InputValue value)
    {
        // Get the value of the input and pass it to the current state
        hebeMoveVector = value.Get<Vector2>();
        // Decide Direction facing
        FacingDirection newDirection = TransformRotater.DecideRotation(hebeMoveVector);
        // Don't update direction if the player isn't holding a direction
        if (newDirection != FacingDirection.Center){
            _hebeDirection = newDirection;
        }
    }

    //Called when player presses the attack button
    public void OnAttack()
    {
        attackSelection = 0;
        _currentState.OnAttack();
    }

    void OnDash()
    {
        _currentState.OnDash();
    }

    void OnSuperDash(){
        _currentState.OnDash();
        _dashState.SetSuperDash();
    }

    void OnSpinAttack(){
        attackManager.OnSpinAttack(_hebeDirection);
    }

    private void OnBowArrow(){
        attackManager.OnArrow(_hebeDirection);
    }

    // Called by animator to make Hebe mobile again.
    public void MakeActionable()
    {
        _currentState.MakeActionable(this);
    }

    public void EndState(){
        ChangePlayerState(_movementState);
    }

    private void OnParticleCollision(GameObject particle){
        freezeLevel += 10;
            if (freezeLevel >= 30){
                freezeLevel = 0;
                attackSelection = 9; // 9 is the "frozen" attack
                ChangePlayerState(_attackState);
            }
    }

    private void OnPlayerDeath(){
        ChangePlayerState(_deadState);
    }
    
}
