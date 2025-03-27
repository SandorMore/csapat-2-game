using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player_Legacy player => GetComponentInParent<Player_Legacy>();
    private void AnimationTrigger()
    {
        player.AnimatopnTrigger();
    }
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if(hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().currentHealth -= player.damage;
            }
        }
    }
    private void DeathTrigger()
    {
        player.Death();
    }
}
