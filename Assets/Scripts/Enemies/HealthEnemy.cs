using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    public Image healthbar;
    // Start is called before the first frame update

    public void takeDamage(float maxHealth, float health)
        {
            healthbar.fillAmount = health/maxHealth;
            
        }

    }



