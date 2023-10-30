using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class Charactermovement : MonoBehaviour
{
    public float speed = 5.0f; // You can adjust the speed to your liking

    private Vector2 targetPosition;

    private Animator animator;

    public Tilemap destroyabledoorTilemap;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 1 is for right mouse button
        {

            
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;

            if (moveDirection.magnitude > 0.1f)
            {
                if (moveDirection.y > 0.1f)
                {
                    SetAnimation("UpTrigger");
                }
                else if (moveDirection.y < -0.1f)
                {
                    SetAnimation("DownTrigger");
                }
                else if (moveDirection.x > 0.1f)
                {
                    SetAnimation("RightTrigger");
                }
                else if (moveDirection.x < -0.1f)
                {
                    SetAnimation("LeftTrigger");
                }
            }
            else
            {
                SetAnimation("IdleTrigger");
            }
        }
        

        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    void SetAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pared"))
        {
            // Evitar que el jugador atraviese la pared
            rb.velocity = Vector2.zero;
        }
    }
}





