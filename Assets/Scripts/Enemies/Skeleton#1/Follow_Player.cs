using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public Boolean EmpezarJuego = false;
    private float distance;
    private Rigidbody2D rb;
    private Boolean detectado = false;
    private int damage;
    public HealthManager health;
    private int healthEnemy;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 20;
        healthEnemy = 100;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EmpezarJuego == true)
        {
            movimientoEnemigo();
            muerteEnemigo();
        }

    }
    public void movimientoEnemigo()
    {
            Vector2 direction = (Player.transform.position - transform.position).normalized;

            // Calcula la velocidad basada en la dirección y la velocidad deseada
            Vector2 velocity = direction * speed;

            // Aplica la velocidad al Rigidbody2D
            rb.velocity = velocity;

            distance = Vector2.Distance(Player.transform.position, transform.position);

        if (Player.transform.position.x > transform.position.x)
        {
            animator.SetBool("WalkLeft", false);
        }
        else
        {
            animator.SetBool("WalkLeft", true);
        }
            
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            // Aquí es donde pones el código para dañar al jugador.
            health.takeDamage(damage);
        }
    }
    public void muerteEnemigo()
    {
        if (healthEnemy == 0)
        {
            Destroy(gameObject);
        }
    }
    public void setHealthEnemy(int playerDamage)
    {
        healthEnemy -= playerDamage;
    }

}
