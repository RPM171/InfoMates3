using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class Charactermovement : MonoBehaviour
{
    public float speed = 5.0f; 
    private Vector2 targetPosition;
    private Rigidbody2D rb;
    public GameObject personaje;
    bool isPaused = false;
    private Animator animator;
    public AnimacionKevin animacion;
    bool idle = false;
    bool boolAttack = false;
    public Player_attack attack;
    
    
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        animacion = GetComponent<AnimacionKevin>();
        animator = GetComponent<Animator>();    
        attack = GetComponent<Player_attack>();
       
        
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
        if (moveDirection.magnitude > 0.1f)
        {
            if (moveDirection.x > 0.1f)
            {
                idle = false;
                animacion.WalkRigth(moveDirection.x);
                if (Input.GetKeyDown(KeyCode.Escape))
                {

                    boolAttack = true;
                    attack.Attack(boolAttack);
                }
                boolAttack = false;
            }
            else if (moveDirection.x < -0.1f)
            {
                idle = false;
                animacion.WalkLeft(moveDirection.x);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                boolAttack = true;
                attack.Attack(boolAttack);
            }
            boolAttack = false;
        }

    }
            else
            {
                idle = true;
                animacion.IdlePlayer(idle);
                
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


}





