using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    private Animator animator;
    public Transform jugador;
    private bool mirandoIzquierda = true;
    private NavMeshAgent agent;
    [SerializeField] private GameObject Victoria;
    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private HealthManager barra;
    private float TiempoDeEspera;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider;
    private Vector2 offsetRigth, offsetLeft;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //barra.FuncionDeIniciar(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        offsetLeft = new Vector2(collider.offset.x + 0.03663f, collider.offset.y);
        offsetRigth = new Vector2(-collider.offset.x , collider.offset.y);
    }

    // Update is called once per frame
    void Update()
    {
        MovementBoss();
        Orientation(jugador.position.x-transform.position.x);
    }
    public void TomarDaño(float damage)
    {
        vida -= damage;
        //barra.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            animator.SetTrigger("dead");
        }

    }
    private void Muerte()
    {
        Destroy(gameObject);
    }
    public void mirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoIzquierda) || (jugador.position.x < transform.position.x && mirandoIzquierda))
        {
            mirandoIzquierda = !mirandoIzquierda;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
    public void GameVictory()
    {
        Time.timeScale = 0;
        Victoria.SetActive(true);
    }
    void MovementBoss()
    {

        TiempoDeEspera = 10f;
        if (Time.time > TiempoDeEspera)
        {
            agent.SetDestination(jugador.position);
        }

    }
    void Orientation(float moveX)
    {
        collider.offset = new Vector2 (collider.offset.x,collider.offset.y);
        if (moveX < 0)
        {
            spriteRenderer.flipX = false;
            collider.offset = offsetLeft;
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = true;
            collider.offset = offsetRigth;
        }
    }
}
