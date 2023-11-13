using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
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
    public AnimacionKevin animacion;
    public Player_attack attack;
    public Animation AttackLeft;
    public Animation AttackRight;
   
    
    
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        animacion = GetComponent<AnimacionKevin>();   
        attack = GetComponent<Player_attack>();
        AttackLeft = GetComponent<Animation>();
        AttackRight = GetComponent<Animation>();




    }

    // Update is called once per frame
   void Update()

{
        Vector2 moveDirection = (targetPosition - rb.position).normalized;
        animacion.WalkRigth(false);
        animacion.WalkLeft(false);
        animacion.Idle(true);
        if (Input.GetMouseButtonDown(1)) 

    {       
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveDirection = (targetPosition - rb.position).normalized;
    }
        if (moveDirection.magnitude > 0.1f)
        {
            
            if (moveDirection.x > 0.1f)
            {
                animacion.Idle(false);
                animacion.WalkRigth(false);
                animacion.WalkLeft(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    AttackLeft.Play();
                }
            }
            else if (moveDirection.x < -0.1f)
            {
                animacion.Idle(false);
                animacion.WalkLeft(false);
                animacion.WalkRigth(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    AttackRight.Play();
                }
            }

            
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





