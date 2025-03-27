using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player_Legacy player;

    protected Rigidbody2D rb;

    protected float stateTimer;
    protected float xInput;
    private string animBoolName;

    protected bool triggerCalled;
    public PlayerState(Player_Legacy _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        rb = player.rb;
        player.anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
        if (player.currentStamina < player.maxStamina && player.regenTimer <= 0)
        {
            player.RegenerateStamina();
        }
        else if (player.regenTimer > 0)
        {
            player.regenTimer -= Time.deltaTime;
        }
        if (!player.isGroundDetected())
        {
            stateMachine.ChangeState(player.airState);
        }
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
