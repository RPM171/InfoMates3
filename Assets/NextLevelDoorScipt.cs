using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoorScipt : MonoBehaviour
{
    private Sprite ClosedLevelDoor;
    public Sprite OpenedLevelDoor;
    private bool isOpen = false;
    private SpriteRenderer spriteRenderer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.E) && PLayerIsNear())
        {
            if(isOpen && Input.GetKeyDown(KeyCode.E))
            {
                //SceneManager.LoadScene("Operacion1");
            } 
            else
            {
                OpenTrapdoor();
            }

        }
    }

    private bool PLayerIsNear()

    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        return distanceToPlayer < 1f;
    }

    private void OpenTrapdoor()
    {
        spriteRenderer.sprite = OpenedLevelDoor;
        isOpen = true;
    }
}
