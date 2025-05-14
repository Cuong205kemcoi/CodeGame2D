using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float dame = 25f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.CompareTag("Player"))
        {
            player.TakeDame(dame);
        }
        if (collision.CompareTag("Enemy"))
        {
            enemy.TakeDame(dame);
        }
    }
    public void DestroyExp()
    {
        Destroy(gameObject);
    }
}
