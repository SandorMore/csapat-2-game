using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Soldier : Enemy
{
    #region States

    public SoldierIdleState idleState { get; private set; }
    public SoldierMoveState moveState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new SoldierIdleState(this, stateMachine, "Idle", this);
        moveState = new SoldierMoveState(this, stateMachine, "Move", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Intitialize(idleState);
    }


    protected override void Update()
    {
        base.Update();
    }
}
