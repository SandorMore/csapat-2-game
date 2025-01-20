using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;
    [Header("Stats")]

    public float moveSpeed;
    public float idleTime;
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float battleTime;
    [Header("Attack Info")]

    public float attackDistance;
    public float attacCoolDown;
    public float lastTimeAttacked;
    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        currentHealth = maxHealth;
        base.Awake();
        stateMachine = new EnemyStateMachine();

    }
    protected override void Update()
    {

        base.Update();
        stateMachine.currentState.Update();
    }
    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, whatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y));
    }
    public virtual void AnimationTriggerFininsh() => stateMachine.currentState.AnimationFinishTrigger();

    public void Death()
    {
        Destroy(gameObject);
    }
}
