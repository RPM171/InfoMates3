using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevinMenu : MonoBehaviour
{
    public float tiempoDeEspera = 2.0f; // Tiempo en segundos antes de poder saltar nuevamente
    private float tiempoUltimoSalto = -2.0f; // Inicializar con un valor negativo para permitir el primer salto
    private bool isGrounded;
    private Rigidbody2D rb;
    public float jumpForce = 10.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Verificar si el personaje está en el suelo
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Saltar si se presiona la tecla de espacio, estás en el suelo y ha pasado suficiente tiempo desde el último salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && Time.time - tiempoUltimoSalto >= tiempoDeEspera)
        {
            Jump();
            tiempoUltimoSalto = Time.time; // Registrar el tiempo del último salto
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}






