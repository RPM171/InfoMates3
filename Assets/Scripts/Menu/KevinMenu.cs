using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevinMenu : MonoBehaviour
{
    public float jumpForce = 5f; // Fuerza de salto
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Verificar si el personaje está en el suelo
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Saltar si se presiona la tecla de espacio o tocas la pantalla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}




