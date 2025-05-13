using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected PlayerController player;
    [SerializeField] protected float maxHp = 50f;
    protected float currentHp;
    [SerializeField] private Image hpBar;
    [SerializeField] protected float enterDame = 10f;
    [SerializeField] protected float staydame = 1f;

    protected virtual void Start()
    {
        player= FindAnyObjectByType<PlayerController>();
        currentHp = maxHp;
        UpdateHpBar();
    }
    protected virtual void Update()
    {
        MoveToPlayer();
    }
    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }
    protected void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);

        }
    }
    public virtual void TakeDame(float dame)
    {

        currentHp -= dame;
        currentHp=Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0) 
        {
            Die();
        }
    }   
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    protected void UpdateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}
