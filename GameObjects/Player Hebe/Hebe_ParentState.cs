using UnityEngine;

public abstract class Hebe_ParentState
{
    // These methods will always be called in the state machine.
    // If a child class does not define them, then they are blank.
    public abstract void StateStart(Player_StateMachine Hebe);

    public virtual void StateExit(Player_StateMachine Hebe){return;}

    public virtual void EnterPlayerState(Player_StateMachine Hebe){return;}

    public virtual void UpdatePlayerState(Player_StateMachine Hebe){return;}

    public virtual void FixedUpdatePlayerState(Player_StateMachine Hebe){return;}

    public virtual void OnMove(Vector2 moveVector){return;}

    public virtual void OnAttack(){return;}

    public virtual void OnDash(){return;}

    public virtual void MakeActionable(Player_StateMachine Hebe){return;}
}
