using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDame(enterDame);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDame(staydame);
            }
        }
    }
    protected override void Die()
    {
        base.Die(); 

    }
}
