using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySoldierAnimationTriggers : MonoBehaviour
{
<<<<<<< HEAD
    private PlayerStateMachine playerStateMachine;
    private Player_Legacy player;
=======
>>>>>>> dbbb4c11799f408e484c53f8c5b0a7759b03eb3e
    private Enemy_Soldier enemy => GetComponentInParent<Enemy_Soldier>();

    private void AnimationTrigger()
    {
        enemy.AnimationTriggerFininsh();
    }
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player_Legacy>() != null)
            {
<<<<<<< HEAD
                hit.GetComponent<Player_Legacy>().currentHealth -= enemy.damage;
=======
                if (hit.GetComponent<Player>().IsBlocking == true)
                {
                    hit.GetComponent<Player>().currentStamina -= 45f;
                }
                if (hit.GetComponent<Player>().IsVoulnerable == true)
                {
                    hit.GetComponent<Player>().currentHealth -= enemy.damage;
                    hit.GetComponent<Player>().Damage();
                }
>>>>>>> dbbb4c11799f408e484c53f8c5b0a7759b03eb3e
            }
        }
    }
    private void DeathTrigger()
    {
        enemy.Death();
    }
}
