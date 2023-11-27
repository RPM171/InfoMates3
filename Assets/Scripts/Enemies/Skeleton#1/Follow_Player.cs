using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow_Player : MonoBehaviour
{
    public GameObject Player;
    private Boolean detectado = false;
    [SerializeField] private int damage;
    public HealthManager health;
    [SerializeField] private int healthEnemy;
    private Animator animator;
    public Transform player;
    private SpriteRenderer spriteRenderer;
    private float distance;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer= GetComponentInChildren<SpriteRenderer>();
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
    public void movimientoEnemigo()
    {
            agent.SetDestination(player.position);
            Orientation(player.position.x-transform.position.x);


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
        if (healthEnemy <= 0)
        {
            if (healthEnemy <= 0)
            {
                animator.SetTrigger("dead");
                agent.speed = 0;

            }
        }
    }
    public void Muerte()
    {
        Destroy(gameObject);
    }
    public void setHealthEnemy(int playerDamage)
    {
        healthEnemy = healthEnemy-playerDamage;
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
            spriteRenderer.flipX = false;
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position+transform.right*distance);
    }

}
