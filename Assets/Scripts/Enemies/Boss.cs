using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [Header("PerseguirJugador")]
    private Animator animator;
    public Transform jugador;
    private bool mirandoIzquierda = true;
    private NavMeshAgent agent;
    [SerializeField] private GameObject Victoria;

    [Header("Vida")]

    [SerializeField] private float maxVida;
    private float vida;
    [SerializeField] private HealthEnemy barra;
    [SerializeField] private GameObject enemyGenerator;
    [SerializeField] private GameObject enemyGenerator2;

    [Header("Ataque")]

    [SerializeField] private float radiusAttack;
    [SerializeField] private Transform checkAttack;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider;
    private Vector2 offsetRigth, offsetLeft;
    [SerializeField] private float timeNextAttack;
    [SerializeField] private float timeIdle;
    private int damage;
    private Color Gold = new Color(0.85f, 0.65f, 0.13f);



    // Start is called before the first frame update
    void Start()
    {
        vida = maxVida;
        barra.takeDamage(maxVida,vida);
        damage = 20;
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

        
        Orientation(jugador.position.x-transform.position.x);
        float distanciaPlayer = Vector2.Distance(jugador.position,transform.position);
        MovementBoss(distanciaPlayer);
        animator.SetFloat("distancia", distanciaPlayer);
        animator.SetFloat("timeAttack", timeNextAttack);
        if (timeNextAttack > 0)
        {
            timeNextAttack -= Time.deltaTime;
        }
        if(vida <= 500)
        {
            spriteRenderer.color = Color.magenta;
            timeIdle = 8f;
            damage = 30;

            if (vida <= 200)
            {
                spriteRenderer.color = Gold;
                damage = 80;
                timeIdle = 3f;
                enemyGenerator.SetActive(true);
                enemyGenerator2.SetActive(true);

            }
        }
    }
    public void TomarDaño(float damage)
    {
        vida -= damage;
        barra.takeDamage(maxVida, vida);
        StartCoroutine(CambiarColorTemporalmente(0.5f));
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
    void MovementBoss(float distancia)
    {

        
        if (distancia<20)
        {
            agent.SetDestination(jugador.position);
        }

    }
    void Orientation(float moveX)
    {
        checkAttack.position = new Vector2(transform.position.x, transform.position.y);
        collider.offset = new Vector2 (collider.offset.x,collider.offset.y);
        if (moveX < 0)
        {
            spriteRenderer.flipX = false;
            collider.offset = offsetLeft;
            checkAttack.position = new Vector2(transform.position.x - 1f, transform.position.y);
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = true;
            collider.offset = offsetRigth;
            checkAttack.position = new Vector2(transform.position.x + 1f, transform.position.y);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkAttack.position, radiusAttack);
    }
    public void resetTimeAttack()
    {
        timeNextAttack = timeIdle;
    }
    public void Damage()
    {
        Collider2D[] objeto = Physics2D.OverlapCircleAll(checkAttack.position, radiusAttack);
        foreach (Collider2D collision in objeto)
        {
            if (collision.CompareTag("Player"))
            {
                GameObject.Find("Player").GetComponent<Charactermovement>().takeDamage(damage);
            }

        }
       

    }
    IEnumerator CambiarColorTemporalmente(float duracion)
    {
        // Cambiar el color a "nuevoColor"
        spriteRenderer.color = Color.red;

        // Esperar la duración especificada
        yield return new WaitForSeconds(duracion);

        // Volver al color original después de la espera
        spriteRenderer.color = Color.white;
    }
}
