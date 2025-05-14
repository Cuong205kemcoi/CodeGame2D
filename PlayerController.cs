using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; //kiem soat toc do di chuyyen
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer ;
    private Animator animator ;
    [SerializeField] private float maxHp = 100f;
    private float currentHp;
    [SerializeField] private Image hpBar;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = playerInput.normalized * moveSpeed;
        //check lật nhân vật
        if (playerInput.x < 0)
        {
            spriteRenderer.flipX = true;    
        }else if (playerInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        //CHuyển đổi animation
        if (playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun",false);
        }
    } 
    public void TakeDame(float dame)
    {
        currentHp -= dame;
        currentHp= Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if(currentHp <= 0)
        {
            Die();
        }
    }
    public void Heal(float heal)
    {
        if(currentHp < maxHp)
        {
            currentHp+= heal;
            currentHp=Mathf.Min(currentHp, maxHp);
            UpdateHpBar();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}
