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

    private float moveX;
    private float moveY;

    public bool tieneCarta = false;
    public Vector3 posicionDestino = new Vector3(-18.13f, -2.53f, 4.21566f);

    public Tilemap destroyabledoorTilemap;

    private float timer = 15f; // Tiempo en segundos para esperar.

    private bool timerStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>();

        if (tieneCarta == true)
        {
            transform.position = posicionDestino;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStarted)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // Coloca aquí el código que deseas ejecutar después de 5 segundos.
                GameObject.Find("GameManager").GetComponent<GameManager>().SetEstatGameManager(GameManager.EstatGameManager.GameOver);
                timerStarted = true; // Para que no se ejecute de nuevo.
            }
        }


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



}

