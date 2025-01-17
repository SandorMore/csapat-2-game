using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public bool isBusy { get; private set; }

    [Header("Move Info")]
    public float moveSpeed = 12f;
    public float jumpForce = 10f;
    [Header("Attack Info")]
    
    public float[] attackMovement;

    [Header("Character Stats")]
    #region Stats
    public float maxHealt = 200f;
    public float currentHealth;
    public float maxStamina = 130f;
    public float currentStamina;
    public float attackStaminaUsage = 10f;
    public float staminaUsage = 15f;
    public float regenDelay = 2f;
    public float regenTimer = 2f;
    public float regenRate = 5f;
    public float rollDistance = 10f;
    public float attackSpeed = 1f;
    public float BASESPEED = 1f;
    public float healPower = 20f;
    public int healAmount = 3;
    #endregion
    [Header("LayerStuff")]

    public bool isRolling;



    #region States
    public PlayerStateMachine stateMachine { get; private set;}

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }

    public PlayerRollState rollState { get; private set; }

    public PlayerPrimaryAttackState primaryAttack { get; private set; }

    public PlayerBlockState blockState { get; private set; }
    #endregion
    public PlayerHealState healState { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine,   "Jump");
        rollState = new PlayerRollState(this, stateMachine, "Roll");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        blockState = new PlayerBlockState(this, stateMachine, "Block");
        healState = new PlayerHealState(this, stateMachine, "Heal");
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialze(idleState);
        currentHealth = maxHealt;
        currentStamina = maxStamina;
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        
    }
    public void AnimatopnTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public void RegenerateStamina()
    {
        currentStamina += regenRate * Time.deltaTime; 
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }
    public void UseStaminaOnAttack()
    {
        if (currentStamina > 0)
        {
            currentStamina -= attackStaminaUsage;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            regenTimer = regenDelay;
        }
    }
    public void UseStamina()
    {
        if (currentStamina > 0)
        {
            currentStamina -= staminaUsage;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); 
            regenTimer = regenDelay; 
        }
    }
    public IEnumerator BusyFor(float _secounds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_secounds);
        isBusy = false;
    }

 
}
