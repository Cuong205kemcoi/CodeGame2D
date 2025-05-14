using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int currentEnemy;
    [SerializeField] private int ennergyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpaner;
    private bool bossCalled= false;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject GameUI;
    void Start()
    {
        currentEnemy = 0;
        UpdateEnergy();
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddEnergy()
    {
        if ((bossCalled))
        {
            return;
        }
        currentEnemy += 1;
        UpdateEnergy();
        if (currentEnemy == ennergyThreshold)
        {
            CallBoss();
        }
    }
    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpaner.SetActive(false);
        GameUI.SetActive(false);
    }
    private void UpdateEnergy()
    {
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnemy / (float)ennergyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }
}
