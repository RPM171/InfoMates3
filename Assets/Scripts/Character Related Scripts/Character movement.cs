using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using UnityEngine.Tilemaps;

public class Charactermovement : MonoBehaviour
{
    [Header("Player")]

    public float speed = 5.0f; 
    private Vector2 targetPosition;
    private Rigidbody2D rb;
    public GameObject personaje;
    bool isPaused = false;
    public AnimacionKevin animacion;
    public Player_attack attack;
    private SpriteRenderer spriteRenderer;
    public Follow_Player enemy;

    [Header("Arm")]
   
    private int damage;
    public Transform attackCheck;
    public float radiusAttack;
    public LayerMask layerEnemy;
    float timeNextAttack;
    public float radius;










    // Start is called before the first frame update
    void Start()
    {
        damage = 20;
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        animacion = GetComponent<AnimacionKevin>();   
        attack = GetComponent<Player_attack>();
        spriteRenderer= GetComponentInChildren<SpriteRenderer>();
        enemy = GetComponent<Follow_Player>();



    }

    // Update is called once per frame
   void Update()

{
        
        Vector2 moveDirection = (targetPosition - rb.position).normalized;
        
        if (Input.GetMouseButtonDown(1)) 

    {       
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveDirection = (targetPosition - rb.position).normalized;
    }
        if (targetPosition != rb.position)
        {
            animacion.Walk(targetPosition.x - rb.position.x);
            OrientationSprite(targetPosition.x - rb.position.x);
            Flip(spriteRenderer.flipX);
        }  

      if (Input.GetKeyDown(KeyCode.Space))
        {   
            animacion.attack();
            PlayerAttack();
        }
        
}

    void OrientationSprite(float moveX)
    {
        if (moveX > 0 )
        {
            spriteRenderer.flipX = true;
            

        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = false;
            
        }
        
    }

    void FixedUpdate()
    {
        if (!isPaused && rb.position != targetPosition)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));
        }
        }

            public void PauseMovement()
        {
            isPaused = true;
        }

        public void ResumeMovement()
        {
            isPaused = false;
        }

     

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pared"))
        {
            // Evitar que el jugador atraviese la pared
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
        

    }
    public void teleportPlayer(GameObject player)
    {
        Vector3 teleport = new Vector3(-18f, -1.22f,0f);
        player.transform.position=teleport;

    }


    // Método para detectar colisiones
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Verifica si colisiona con el jugador
        {
            // Aquí puedes ejecutar la lógica para causar daño al jugador
            enemy.setHealthEnemy(attack.damage);
        }
    }

    public int GetDamage()
    {
        return damage;
    
    }
    void Flip(bool flipPlayer)
    {
        if (flipPlayer==true)
        {
            attackCheck.localPosition = new Vector2(+attackCheck.localPosition.x, attackCheck.localPosition.y);
        }
        else if (flipPlayer == false)
        {
            attackCheck.localPosition = new Vector2(-attackCheck.localPosition.x, attackCheck.localPosition.y);
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(attackCheck.position, radiusAttack);
    }
    void PlayerAttack()
    {
        Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll(attackCheck.position, radiusAttack, layerEnemy);
        for (int i = 0; i < enemiesAttack.Length; i++)
        {
            
            Debug.Log(enemiesAttack[i].name);
        }
        enemy.setHealthEnemy(damage);
    }
}





