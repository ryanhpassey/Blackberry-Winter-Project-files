using UnityEngine;

public class Beth_ParentState
{
    public virtual void StateStart(Beth_StateMachine Beth){return;}

    public virtual void EnterState(Beth_StateMachine Beth){return;}

    public virtual void UpdateState(Beth_StateMachine Beth){return;}

    public virtual void FixedUpdateState(Beth_StateMachine Beth){return;}

    public virtual void ExitState(Beth_StateMachine Beth){return;}

    public virtual void OnAnimationEnd(Beth_StateMachine Beth){return;}
}
