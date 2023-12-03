using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Follow_Player : MonoBehaviour
{
    public GameObject Player;
    private Boolean detectado = false;
    [SerializeField] private int damage;
    public HealthManager health;
    [SerializeField] private float healthEnemy;
    private Animator animator;
    public Transform player;
    private SpriteRenderer spriteRenderer;
    private float distance;
    private NavMeshAgent agent;
    [SerializeField] private Transform chechAttack;
    [SerializeField] private float radiusAttack;
    [SerializeField] private Transform checkAttack;
    [SerializeField] private HealthEnemy scriptHealth;
    private float healtActual;




    // Start is called before the first frame update
    void Start()
    {

        healtActual = healthEnemy;
        scriptHealth.takeDamage(healthEnemy, healtActual);
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


    }

    // Update is called once per frame
    void Update()
    {
        movimientoEnemigo();
        AnimacionMuerte();
        distancePlayer(distance);
        if (detectado == true)
        {
            animator.SetTrigger("attack");
        }


    }
    private void Attack()
    {
        Collider2D[] objeto = Physics2D.OverlapCircleAll(chechAttack.position, radiusAttack);
        foreach (Collider2D collision in objeto)
        {
            if (collision.CompareTag("Player"))
            {
                dmgEnemy();
            }
        }
    }
    private void AttackR()
    {
        Collider2D[] objeto = Physics2D.OverlapCircleAll(checkAttack.position, radiusAttack);
        foreach (Collider2D collision in objeto)
        {
            if (collision.CompareTag("Player"))
            {
                dmgEnemy();
            }
        }
    }
    public void movimientoEnemigo()
    {
        if (agent != null && player != null)
        {
            if (agent.isOnNavMesh && agent.isActiveAndEnabled)
            {
                agent.SetDestination(player.position);
                Orientation(player.position.x - transform.position.x);
            }
        }



        if (Player.transform.position.x > transform.position.x)
        {
            animator.SetBool("WalkLeft", false);
        }
        else
        {
            animator.SetBool("WalkLeft", true);
        }


    }

    public void AnimacionMuerte()
    { 
    if (healtActual <= 0)
            {
              
              animator.SetTrigger("dead");     
            }
    }
    public void Muerte()
    {
       // FindObjectOfType<GameManager>().IncrementarEnemigosMuertos();
        Destroy(gameObject);

    }
    public void setHealthEnemy(int playerDamage)
    {

        healtActual = healtActual - playerDamage;
        scriptHealth.takeDamage(healthEnemy, healtActual);
        StartCoroutine(CambiarColorTemporalmente(0.5f));
        


    }
    public void distancePlayer(float dist)
    {
        dist = Vector2.Distance(transform.position, player.position);

        if (distance < 0.1)
        {
            detectado = true;
        }
        else if (distance > 0.1)
        {
            detectado = false;
        }
    }

    void Orientation(float moveX)
    {
        if (moveX < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(chechAttack.position, radiusAttack);
        Gizmos.DrawWireSphere(checkAttack.position, radiusAttack);
    }


    public void dmgEnemy()
    {
        GameObject.Find("Player").GetComponent<Charactermovement>().takeDamage(damage);
    }
    
    IEnumerator CambiarColorTemporalmente(float duracion)
    {
        // Cambiar el color a "nuevoColor"
        spriteRenderer.color = Color.red;

        // Esperar la duración especificada
        yield return new WaitForSeconds(duracion);

        // Volver al color original después de la espera
        spriteRenderer.color = Color.white;
    }
   
}