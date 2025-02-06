using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorthalJumpAttackState : EnemyState
{
    private Vorthal enemy;
    public float jumpSpeed = 1.3f;
    public float jumpHeight = 2.4f;

    private Transform player;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float jumpProgress = 0f;
    private bool isJumping = false;

    public VorthalJumpAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Vorthal _enemy)
        : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        player = playerObject.transform;

       
        JumpToPlayer();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (isJumping == false)
        {
            enemy.damage = 20;
        }
        if (isJumping)
        {
            enemy.attackCheckRadius = 5f;
            enemy.damage = 50;
            jumpProgress += Time.deltaTime * jumpSpeed;
            jumpProgress = Mathf.Clamp01(jumpProgress);

            float heightOffset = Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight;
            enemy.transform.position = Vector3.Lerp(startPosition, targetPosition, jumpProgress)+ Vector3.up * heightOffset;
            if (enemy.isGroundDetected())
            {
                isJumping = false;
                enemy.damage = 20;
                stateMachine.ChangeState(enemy.battleState);
            }
            if (jumpProgress >= 1f)
            {
                
                isJumping = false;
                enemy.damage = 20;

                enemy.transform.position = new Vector3(enemy.transform.position.x, targetPosition.y + 1f, enemy.transform.position.z);
                stateMachine.ChangeState(enemy.battleState);
            }
        }
    }

    private void JumpToPlayer()
    {

        startPosition = enemy.transform.position;
        targetPosition = player.position;
        jumpProgress = 0f;
        isJumping = true;
    }
}
