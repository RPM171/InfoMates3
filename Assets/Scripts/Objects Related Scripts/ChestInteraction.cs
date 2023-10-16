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
    public GameObject Historia;
    // Start is called before the first frame update
    private void Start()
    {
            
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactionCollider = GetComponent<CircleCollider2D>();


    }
    private void Update()
    {
        float contador = 0;
        if (Input.GetKeyDown(KeyCode.E) && IsCharacterWithinRadius()&&contador!=1)
        {
            animator.SetTrigger("Open");
            spriteRenderer.sprite = isOpenSprite;
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            Pergamino.SetActive(true);
            Historia.SetActive(true);
            contador = 1;
           
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

 

    

