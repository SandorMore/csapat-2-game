using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorthalIdleState : EnemyState
{
    private Vorthal enemy;
    protected Transform player;
    public VorthalIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Vorthal _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < 30)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
