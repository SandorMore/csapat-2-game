using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 0.75f;
    public PlayerPrimaryAttackState(Player_Legacy _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter >2 || Time.time >= lastTimeAttacked + comboWindow)
        {
            comboCounter = 0;
        }
        if (player.attackSpeed > 0)
        {
            player.anim.speed = player.attackSpeed;
        }
        player.anim.SetInteger("ComboCounter", comboCounter);


        float attackDir = player.facingDir;

        if (xInput != 0)
        {
            attackDir = xInput;
        }


        player.SetVelocity(player.attackMovement[comboCounter] * attackDir, rb.velocity.y);
        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttacked = Time.time;

        player.StartCoroutine("BusyFor", 0.15f);
        player.anim.speed = player.BASESPEED;
    }

    public override void Update()
    {
        if (stateTimer < 0)
        {
            player.ZeroVelocity();
        }
        base.Update();
        if (triggerCalled == true)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}
