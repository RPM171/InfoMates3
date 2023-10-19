using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Sprite isOpenSprite;
    private CircleCollider2D interactionCollider;
    public GameObject Pergamino;
    public float contador;

    // Start is called before the first frame update
    private void Start()
    {
          
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactionCollider = GetComponent<CircleCollider2D>();
        contador = 0;


    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && IsCharacterWithinRadius())
        {
            if (contador != 1)
            {
                animator.SetTrigger("Open");
                spriteRenderer.sprite = isOpenSprite;
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                Pergamino.SetActive(true);
                contador = 1;
            }
            else
            {
                animator.SetTrigger("Open");
                spriteRenderer.sprite = isOpenSprite;
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                Debug.Log("El cofre esta vacio");
            }

        }
        
    }
    private bool IsCharacterWithinRadius()
    {
        if (interactionCollider != null)

        {
            Collider2D[] colliders = new Collider2D[1];
            return interactionCollider.OverlapCollider(new ContactFilter2D(), colliders) > 0;

        }
        return false;
    }
}

 

    

