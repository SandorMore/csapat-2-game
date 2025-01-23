using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : SoldierGroundedState
{
    public SoldierIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Soldier enemy) : base(_enemyBase, _stateMachine, _animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if ( stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
