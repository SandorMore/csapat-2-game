using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (player.currentHealth <= 0)
        {
            stateMachine.ChangeState(player.deathState);
        }
        if (Input.GetKeyDown(KeyCode.Q) && player.healAmount != 0 && player.currentHealth != player.maxHealt)
        {
            stateMachine.ChangeState(player.healState);

        }
        if (Input.GetKey(KeyCode.Mouse0) && player.currentStamina > player.attackStaminaUsage)
        {
            player.UseStaminaOnAttack();
            stateMachine.ChangeState(player.primaryAttack);
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.currentStamina > player.staminaUsage)
        {
            player.UseStamina();
            stateMachine.ChangeState(player.rollState);
        }
        base.Update();
        if (Input.GetKeyDown(KeyCode.LeftShift) && player.isGroundDetected() && player.currentStamina > player.staminaUsage)
        {
                player.UseStamina();
                stateMachine.ChangeState(player.jumpState);
        }
        if (Input.GetKey(KeyCode.Mouse1) && player.currentStamina >= 45)
        {
            stateMachine.ChangeState(player.blockState);
        }
    }
}
