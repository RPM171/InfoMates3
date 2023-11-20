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
    public float speed = 5.0f; 
    private Vector2 targetPosition;
    private Rigidbody2D rb;
    public GameObject personaje;
    bool isPaused = false;
    public AnimacionKevin animacion;
    public Player_attack attack;
    private SpriteRenderer spriteRenderer;
    public Follow_Player enemy;
    private CapsuleCollider2D RigthAttack;
    private CircleCollider2D LeftAttack;








    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        animacion = GetComponent<AnimacionKevin>();   
        attack = GetComponent<Player_attack>();
        spriteRenderer= GetComponentInChildren<SpriteRenderer>();
        enemy = GetComponent<Follow_Player>();
        RigthAttack = GetComponent<CapsuleCollider2D>();
        LeftAttack = GetComponent<CircleCollider2D>();
        RigthAttack.enabled = false;
        LeftAttack.enabled = false;


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
        }  

      if (Input.GetKeyDown(KeyCode.Space))
        {   
            ActivarEspadaCollider(targetPosition.x - rb.position.x);
            animacion.attack(); 
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
        }
    }
    public void teleportPlayer(GameObject player)
    {
        Vector3 teleport = new Vector3(-18f, -1.22f,0f);
        player.transform.position=teleport;


    }
    public void ActivarEspadaCollider(float moveX)
    {
        if (moveX > 0)
        {
            RigthAttack.enabled = true;
        }
        else if (moveX < 0)
        {
            LeftAttack.enabled = true;
        }
    }

    // Método para desactivar el collider de la espada
    public void DesactivarEspadaCollider()
    {
        RigthAttack.enabled = false;
        LeftAttack.enabled = false; 
    }

    // Método para detectar colisiones
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((RigthAttack.enabled||LeftAttack.enabled) && other.CompareTag("Enemy"))
        {
            enemy.setHealthEnemy(attack.damage);
        }
    }


}





