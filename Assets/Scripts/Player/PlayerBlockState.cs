using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockState : PlayerState
{
    public PlayerBlockState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
        player.ZeroVelocity();
    }

    public override void Update()
    {
        base.Update();
        player.ZeroVelocity();
        if (player.isGroundDetected() && !Input.GetKey(KeyCode.Mouse1))
        {
            stateMachine.ChangeState(player.idleState);
            
        }
    }
}
