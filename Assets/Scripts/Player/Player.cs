using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
<<<<<<< HEAD
=======
    #region General
    public bool isBusy { get; private set; }
>>>>>>> dbbb4c11799f408e484c53f8c5b0a7759b03eb3e

    public Ability moveAbility;
    public Ability jumpAbility;
    public Ability dodgeAbility;
    public Ability attackAbility;
    public Ability healAbility;

<<<<<<< HEAD
    public void InputPress(Ability abilityToStart)
    {
        abilityToStart.StartAbility();
=======
    public float[] attackMovement;
    #endregion
    #region Basestats
    [Header("Player Base Stats")]
    public int vigor = 10;
    public int endurance = 10;
    public int agility = 10;
    public int strength = 10;
    public int dexterity = 10;
    public int spirit = 10;
    #endregion

    #region Stats
    [Header("Player In-Game Stats")]
    public float maxHealt = 20f;
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
    public float damage = 25f;
    public int souls = 0;

    public bool IsBlocking = false;
    public bool IsVoulnerable = true;
    [HideInInspector] public int playerFacingDir { get; private set; } = 1;
    [HideInInspector] public bool canRegen = true;
    #endregion
    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }

    public PlayerRollState rollState { get; private set; }

    public PlayerPrimaryAttackState primaryAttack { get; private set; }

    public PlayerBlockState blockState { get; private set; }

    public PlayerHealState healState { get; private set; }
    public PlayerDeathState deathState { get; private set; }
    #endregion
    protected override void Awake()
    {

        base.Awake();
        stateMachine = new PlayerStateMachine();
        #region InvokeStates
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        rollState = new PlayerRollState(this, stateMachine, "Roll");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        blockState = new PlayerBlockState(this, stateMachine, "Block");
        healState = new PlayerHealState(this, stateMachine, "Heal");
        deathState = new PlayerDeathState(this, stateMachine, "Death");
        #endregion
>>>>>>> dbbb4c11799f408e484c53f8c5b0a7759b03eb3e
    }
    public void InputRelease(Ability abilityToStart)
    {
        abilityToStart.InputRelease();
    }
    public void MovementInput(float xInput)
    {
<<<<<<< HEAD
        ( (GroundMoveAbility) moveAbility ).AddMovementInput(new Vector2(xInput, 0), false, true);
=======
        base.Update();
        stateMachine.currentState.Update();
        
    }
    public void AnimatopnTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public void RegenerateStamina()
    {
        if (canRegen)
        {
            currentStamina += regenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }

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
    public void Death()
    {
        Debug.Log("You died");
    }
    public override void Flip()
    {
        playerFacingDir = playerFacingDir * -1;
        facingRight = !facingRight;
        anim.transform.Rotate(0, 180, 0);
    }
    public override void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
        {
            Flip();
        }
        else if (0 > _x && facingRight)
        {
            Flip();
        }
>>>>>>> dbbb4c11799f408e484c53f8c5b0a7759b03eb3e
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
