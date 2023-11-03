using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthbar;
    public float healthAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            takeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Heal(10);
        }
    }
    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthbar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthbar.fillAmount = healthAmount / 100f;
    }
}
