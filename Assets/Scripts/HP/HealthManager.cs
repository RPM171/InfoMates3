using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthbar;
    private float healthAmount=1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().SetEstatGameManager(GameManager.EstatGameManager.GameOver);
            Time.timeScale = 0;
        }
    }
    public void healtPlayer(float maxHealth, float health)
    {
        healthAmount = health;
        healthbar.fillAmount = health / maxHealth;
        
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthbar.fillAmount = healthAmount / 100f;
    }
   
}
