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
using UnityEngine.SceneManagement;

public class Charactermovement : MonoBehaviour
{
    [Header("Player")]

    public float speed = 5.0f; 
    private Vector2 targetPosition;
    private Rigidbody2D rb;
    public GameObject personaje;
    bool isPaused = false;
    public AnimacionKevin animacion;
    private SpriteRenderer spriteRenderer;
    public Follow_Player enemy;
    public Transform attackCheck;
    private Player_attack attack;
    private string escena;

    [Header("Vida")]

    [SerializeField] private HealthManager healthManager;
    [SerializeField] public float maxHealth;
    private float health;

    [Header("Pociones")]
    public int Problema;
    public int Solucion;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        animacion = GetComponent<AnimacionKevin>();   
        spriteRenderer= GetComponentInChildren<SpriteRenderer>();
        enemy = GetComponent<Follow_Player>();
        attack = GetComponent<Player_attack>();
        PlayerPrefs.SetString("NombreEscenaActual", SceneManager.GetActiveScene().name);
        

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

        
}

    void OrientationSprite(float moveX)
    {
        attackCheck.position = new Vector2(transform.position.x,transform.position.y);
        if (moveX > 0 )
        {
            spriteRenderer.flipX = true;
            attackCheck.position = new Vector2(transform.position.x + 0.6f, transform.position.y);


        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = false;
            attackCheck.position = new Vector2(transform.position.x - 0.6f, transform.position.y);

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
    public void takeDamage(int damage)
    {
        health -= damage;
        healthManager.healtPlayer(maxHealth, health);
        StartCoroutine(CambiarColorTemporalmente(0.5f));

    }
    IEnumerator CambiarColorTemporalmente(float duracion)
    {
        // Cambiar el color a "nuevoColor"
        spriteRenderer.color = Color.red;

        // Esperar la duraci�n especificada
        yield return new WaitForSeconds(duracion);

        // Volver al color original despu�s de la espera
        spriteRenderer.color = Color.white;
    }
}





