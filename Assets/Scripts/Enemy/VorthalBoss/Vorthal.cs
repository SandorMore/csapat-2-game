using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vorthal : Enemy
{
    public float distanceToPlayer;
    public float attackSpeed = 1.28f;
    public float[] attackMovement;
    public float BASESPEED = 1f;
    public bool isBossFight = false;
    public int phase = 1;
    public bool isStopped = false;
    [HideInInspector] public int playerFacingDir { get; private set; } = 1;
    #region States

    public VorthalIdleState idleState { get; private set; }
    public VorthalMoveState moveState { get; private set; }
    public VorthalDeathState deathState { get; private set; }
    public VorthalAttackState attackState { get; private set; }
    public VorthalBattleState battleState { get; private set; }
    public VorthalJumpAttackState jumpAttackState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        idleState = new VorthalIdleState(this, stateMachine, "Idle", this);
        moveState = new VorthalMoveState(this, stateMachine, "Walk", this);
        attackState = new VorthalAttackState(this, stateMachine, "Attack", this);
        battleState = new VorthalBattleState(this, stateMachine, "Walk", this);
        deathState = new VorthalDeathState(this, stateMachine, "Death", this);
        jumpAttackState = new VorthalJumpAttackState(this, stateMachine, "JumpAttack", this);
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Intitialize(idleState);
    }
    protected override void Update()
    {
        base.Update();
        distanceToPlayer = IsPlayerDetected().distance;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            phase++;
        }
    }
    public override RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 100, whatIsPlayer);

    public void AnimatopnTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public override void Flip()
    {
        playerFacingDir = playerFacingDir * -1;
        facingRight = !facingRight;
        anim.transform.Rotate(0, 180, 0);
    }
    public void StopEnemy()
    {
        StartCoroutine(StopEnemyCorutine());
    }
    public IEnumerator StopEnemyCorutine()
    {
        moveSpeed = 0;
        yield return new WaitForSecondsRealtime(1.3f);
        moveSpeed = 5f;
    }
}
