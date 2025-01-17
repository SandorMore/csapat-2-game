using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerState
{
    public PlayerRollState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.isRolling = true;
        stateTimer = 0.5f;

    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rb.velocity.y);
        player.isRolling = false;
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.facingDir * player.rollDistance, rb.velocity.y);

        if (0 > stateTimer)
        {
            
            stateMachine.ChangeState(player.idleState);
        }
    }
}
