using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Soldier : Enemy
{
    public float distanceToPlayer;
    #region States

    public SoldierIdleState idleState { get; private set; }
    public SoldierMoveState moveState { get; private set; }
    public SoldierBattleState battleState { get; private set; }
    
    public SoldierAttackState attackState { get; private set; }

    public SoldierDeathState deathState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new SoldierIdleState(this, stateMachine, "Idle", this);
        moveState = new SoldierMoveState(this, stateMachine, "Move", this);
        battleState = new SoldierBattleState(this, stateMachine, "Move", this);
        attackState = new SoldierAttackState(this, stateMachine, "Attack", this);
        deathState = new SoldierDeathState(this, stateMachine, "Death", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Intitialize(idleState);
    }


    protected override void Update()
    {
        distanceToPlayer = IsPlayerDetected().distance;
        base.Update();
    }
}
