using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedDanThuong = 20f;
    [SerializeField] private float speedDanVongTron = 10f;
    [SerializeField] private float hpValue = 100f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 3f;
    private float nextSkillTime = 0f;
    [SerializeField] private GameObject usbPrefabs;
    protected override void Update()
    {
        base.Update();
        if(Time.time > nextSkillTime)
        {
            SuDungSkill();
        }
    }
    protected override void Die()
    {

        Instantiate(usbPrefabs, transform.position, Quaternion.identity);
        base.Die();
    }
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
            player.TakeDame(staydame);
        }
    }
    private void BanDanThuong()
    {
        if (player != null)
        {
            Vector3 directionToPlayer=player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs,firePoint.position,Quaternion.identity);
            EnemyBullet enemyBullet=bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedDanThuong);
        }
    }
    private void BanDanVongTron()
    {
        const int bulletCount = 10;
        float angleStep =360f / bulletCount;
        for(int i=0; i < bulletCount; i++)
        {
            float angle = i* angleStep;
            Vector3 bullerDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle),Mathf.Sin(Mathf.Deg2Rad*angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs,transform.position,Quaternion.identity);
            EnemyBullet enemyBullet=bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bullerDirection* speedDanVongTron);
        }
    }
    private void HoiMau(float Hpamount)
    {
        currentHp=Mathf.Min(currentHp+Hpamount ,maxHp);
        UpdateHpBar();
    }
    private void SinhMiniEnemy()
    {
        Instantiate(miniEnemy,transform.position,Quaternion.identity);
    }
    private void DIchChuyen()
    {
        if(player != null){
            transform.position = player.transform.position; 
        }
    }
    private void ChonSkill()
    {
        int RandomSkill = Random.Range(0, 5);
        switch (RandomSkill)
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanVongTron();
                break;
            case 2:
                HoiMau(hpValue);
                break;
            case 3:
                SinhMiniEnemy();
                break;
            case 4:
                DIchChuyen();
                break;
        }
    }
    private void SuDungSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        ChonSkill();
    }
}
