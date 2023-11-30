using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    public Transform jugador;
    private bool mirandoIzquierda = true;

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private HealthManager barra;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //barra.FuncionDeIniciar(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if((jugador.position.x > transform.position.x && !mirandoIzquierda) || (jugador.position.x < transform.position.x && mirandoIzquierda))
        {
            mirandoIzquierda = !mirandoIzquierda;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
}
