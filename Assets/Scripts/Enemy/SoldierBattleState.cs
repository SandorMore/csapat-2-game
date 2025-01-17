using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBattleState : EnemyState
{
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
        base.Update();
        if (enemy.IsPlayerDetected())
        {
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                Debug.Log("Nigga");
                enemy.SetVelocity(0, 0);
                return;
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
        enemy.SetVelocity(enemy.moveSpeed * moveDir * 1.39f, rb.velocity.y);
    }
}
