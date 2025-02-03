using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorthalAttackState : EnemyState
{

    private Vorthal enemy;
    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 2f;
    private int facingDir;

    public VorthalAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Vorthal _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        if (enemy.phase == 2)
        {
            enemy.attackSpeed = 1.24f;
            enemy.damage = 35;
            enemy.moveSpeed = 6;
        }
        base.Enter();

        if (comboCounter == 3)
        {
            if(enemy.phase == 2)
            {
                enemy.damage = 75;
            }
            
        }
        if (comboCounter > 3 || Time.time >= lastTimeAttacked + comboWindow)
        {
            comboCounter = 0;
        }
        if (enemy.attackSpeed > 0)
        {
            enemy.anim.speed = enemy.attackSpeed;
        }
        enemy.anim.SetInteger("ComboCounter", comboCounter);


        enemy.SetVelocity(enemy.attackMovement[comboCounter] * facingDir, rb.velocity.y);
        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttacked = Time.time;

        enemy.anim.speed = enemy.BASESPEED;
    }

    public override void Update()
    {
        if (stateTimer < 0)
        {
            enemy.ZeroVelocity();
        }
        base.Update();
        if (triggerCalled == true)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
