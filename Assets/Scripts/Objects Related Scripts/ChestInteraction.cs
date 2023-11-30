using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChestInteraction : MonoBehaviour
{
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Sprite isOpenSprite;
    public Charactermovement charactermovement;
    private CircleCollider2D interactionCollider;
    public GameObject Pergamino;
    private float contador;
    public Camera mainCamera;
    private Vector3 lockedCameraPosition;
    bool Open = false;
    

  
    // Start is called before the first frame update
    private void Start()
    {
        lockedCameraPosition = new Vector3(-18.52f, 6.61f, -10.0f);
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactionCollider = GetComponent<CircleCollider2D>();
        contador = 0;

        
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && IsCharacterWithinRadius() && Open == false)
        {
            if (contador != 1)
            {
                animator.SetTrigger("Open");
                spriteRenderer.sprite = isOpenSprite;
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                Pergamino.SetActive(true);
                contador = 1;
                mainCamera.transform.position = lockedCameraPosition;
                charactermovement.speed = 0;
                Open = true;
                
            }
            else
            {
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

 

    

