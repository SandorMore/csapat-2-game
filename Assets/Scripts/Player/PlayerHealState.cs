using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealState : PlayerState
{
    public PlayerHealState(Player_Legacy _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = .6f;
        player.ZeroVelocity();
        if (player.currentHealth != player.maxHealt && player.healAmount != 0)
        {
            player.currentHealth += player.healPower;
            if (player.healAmount != 0)
            {
                player.healAmount -= 1;
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        player.ZeroVelocity();
        base.Update();
        if (0 > stateTimer)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
