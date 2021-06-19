using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public StateMachine owner;

    public virtual void PrepareState() { }

    public virtual void UpdateState() { }

    public virtual void DestroyState() { }

    public virtual void HandleInput() { }

}
