using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public GameObject Player;
    private float speed;
    public Boolean EmpezarJuego = false;
    private Rigidbody2D rb;
    private Boolean detectado = false;
    private int damage;
    public HealthManager health;
    private int healthEnemy;
    private Animator animator;
    public Transform player;
    private SpriteRenderer spriteRenderer;
    private float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 5;
        speed = 2;
        healthEnemy = 100;
        animator = GetComponent<Animator>();
        spriteRenderer= GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EmpezarJuego == true)
        {
            movimientoEnemigo();
            muerteEnemigo();
            distancePlayer(distance);
            if (detectado == true) 
            {
                animator.SetTrigger("attack");
            }
        }

    }
    public void movimientoEnemigo()
    {
            Vector2 direction = (Player.transform.position - transform.position).normalized;

            // Calcula la velocidad basada en la direcci�n y la velocidad deseada
            Vector2 velocity = direction * speed;

            // Aplica la velocidad al Rigidbody2D
            rb.velocity = velocity;
            Orientation(direction.x);


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
            //El c�digo para da�ar al jugador.
            health.takeDamage(damage);
        }
    }
    public void muerteEnemigo()
    {
        if (healthEnemy == 0)
        {
            animator.SetTrigger("dead");
            DestroyAfterAnimationCoroutine();
        }
    }
    public void setHealthEnemy(int playerDamage)
    {
        healthEnemy -= playerDamage;
    }
    public void distancePlayer(float dist)
    {
        dist = Vector2.Distance(transform.position, player.position);

        if (distance < 0.1)
        {
            detectado = true;
        }else if (distance > 0.1)
        {
            detectado = false;
        }
    }

    void Orientation (float moveX)
    {
        if (moveX<0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    IEnumerator DestroyAfterAnimationCoroutine()
    {
        // Esperar hasta que la animaci�n haya terminado
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Una vez que la animaci�n ha terminado, destruir el objeto
        Destroy(gameObject);
    }

}
