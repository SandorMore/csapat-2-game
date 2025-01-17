using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Stats")]

    public float moveSpeed;
    public float idleTime;
    public float maxHealth;
    public float currentHealth;
    public float damage;
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
}
