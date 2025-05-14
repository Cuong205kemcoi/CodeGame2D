using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : Enemy
{
    [SerializeField] private GameObject Explostion;

    private void CreateExplosion()
    {
        if(Explostion != null)
        {
            Instantiate(Explostion, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CreateExplosion();
        }
    }
    protected override void Die()
    {
        CreateExplosion();
        base.Die();
    }
}
