using System.Collections;
using UnityEngine;


public class NextLevelDoorScipt : MonoBehaviour
{
    private Sprite ClosedLevelDoor;
    public Sprite OpenedLevelDoor;
    private bool isOpen = false;
    private SpriteRenderer spriteRenderer;
    private GameObject player;
    public float contador;
    [SerializeField] private GameObject aviso;
    [SerializeField] private GameManager enemy;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        contador = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        contador = GameManager.instance.enemigosMuertos;
        if (Input.GetKeyDown(KeyCode.E) && PLayerIsNear()&& contador >= 15)
        {
            OpenTrapdoor();

            if (isOpen && Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("SceneManager").GetComponent<Scenes>().ScenaMates();
            }


        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && PLayerIsNear())
            {
                if (contador <= 14)
                {
                    aviso.SetActive(true);
                    StartCoroutine(DesactivarAvisoDespuesDeTiempo(2f));

                }
               
            }
        }
    }
    IEnumerator DesactivarAvisoDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Espera el tiempo especificado

        // Desactiva el aviso despu�s del tiempo especificado
        aviso.SetActive(false);
    }

    private bool PLayerIsNear()

    {
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        return distanceToPlayer < 4f;
    }

    private void OpenTrapdoor()
    {
        spriteRenderer.sprite = OpenedLevelDoor;
        isOpen = true;
    }
}
