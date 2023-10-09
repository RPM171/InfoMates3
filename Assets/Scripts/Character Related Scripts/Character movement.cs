using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Charactermovement : MonoBehaviour
{
    public float speed = 5.0f; // You can adjust the speed to your liking

    private Vector2 targetPosition;

    private Animator animator;

    private float moveX;
    private float moveY;

    public bool tieneCarta = false;
    public Vector3 posicionDestino = new Vector3(-18.13f, -2.53f, 4.21566f);



    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (tieneCarta)
        {
            transform.position = posicionDestino;
            tieneCarta = false;
        }


        if (Input.GetMouseButtonDown(1)) // 1 is for right mouse button
        {

            
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;

            animator.SetFloat("MoveX", moveDirection.x);
            animator.SetFloat("MoveY",moveDirection.y);
        }
        else
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }

        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    
    }

