using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorthalBattleState : EnemyState
{
    private Vorthal enemy;
    private Transform player;
    private int moveDir;
    public VorthalBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Vorthal _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
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
        if(enemy.IsPlayerDetected().distance > 10)
        {
            stateMachine.ChangeState(enemy.jumpAttackState);
        }
        if (enemy.transform.position != player.position)
        {
            enemy.SetVelocity(enemy.moveSpeed * moveDir * 1.39f, rb.velocity.y);
        }
        if (enemy.currentHealth <= 0)
        {
            stateMachine.ChangeState(enemy.deathState);
        }
        base.Update();
        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;

            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                {
                    stateMachine.ChangeState(enemy.attackState);
                }
            }
        }
        float distanceToPlayerX = Mathf.Abs(player.position.x - enemy.transform.position.x);

        if (distanceToPlayerX < 0.2f)
        {
            return;
        }
        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }

    }
    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attacCoolDown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}
