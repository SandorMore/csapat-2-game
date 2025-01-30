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
        player.IsVoulnerable = false;
        player.canRegen = false;
    }

    public override void Exit()
    {
        base.Exit();
        player.ZeroVelocity();
        player.IsVoulnerable = true;

    }

    public override void Update()
    {
        base.Update();
        player.ZeroVelocity();
        
        if (player.isGroundDetected() && !Input.GetKey(KeyCode.Mouse1) ||player.currentStamina <= 45)
        {
            player.canRegen = true;
            stateMachine.ChangeState(player.idleState);
            
        }
    }
}
