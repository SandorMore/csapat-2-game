using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySoldierAnimationTriggers : MonoBehaviour
{
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
            if (hit.GetComponent<Player>() != null)
            {
                if (hit.GetComponent<Player>().IsVoulnerable == true)
                {
                    hit.GetComponent<Player>().currentHealth -= enemy.damage;
                }
            }
        }
    }
    private void DeathTrigger()
    {
        enemy.Death();
    }
}
