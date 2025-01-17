using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : EnemyState
{
    private Enemy_Soldier enemy;
    public SoldierIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Soldier _enemy) : base(_enemy, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
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
