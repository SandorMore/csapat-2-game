using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierBattleState : EnemyState
{
    private float waitTime;
    private int moveDir;
    private Transform player;
    private Enemy_Soldier enemy;
    public SoldierBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Soldier enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
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
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 11)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
        if(player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if(player.position.x < enemy.transform.position.x)
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
