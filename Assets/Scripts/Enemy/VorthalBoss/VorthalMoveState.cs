using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorthalMoveState : EnemyState
{
    private Vorthal enemy;
    protected Transform player;
    public VorthalMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Vorthal _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

        if (enemy.isWallDetected() || !enemy.isGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < 30)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
