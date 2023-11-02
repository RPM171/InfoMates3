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
    public Animator animator;
    
    
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        animator= GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
   void Update()
{
    if (Input.GetMouseButtonDown(1)) // 1 is for right mouse button
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 moveDirection = (targetPosition - rb.position).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            if (moveDirection.x > 0.1f)
            {
                    animator.SetTrigger("RightTrigger");
            }
            else if (moveDirection.x < -0.1f)
            {
                    animator.SetTrigger("LeftTrigger");
            }
            }
            else
            {
                animator.SetTrigger("IdleTrigger");
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





