using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNextLvl : MonoBehaviour
{

        private bool isOpen = false;
        [SerializeField]private GameObject prebaf;
        private GameObject player;
        public float contador;
        [SerializeField] private GameObject aviso;
        [SerializeField] private GameManager enemy;
        // Start is called before the first frame update
        void Start()
        {
            
            player = GameObject.FindWithTag("Player");
            contador = 0;


        }

        // Update is called once per frame
        void Update()
        {
            contador = GameManager.instance.enemigosMuertos;
            if (Input.GetKeyDown(KeyCode.E) && PLayerIsNear() && contador >= 10)
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
                    if (contador <= 9)
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

            // Desactiva el aviso después del tiempo especificado
            aviso.SetActive(false);
        }

        private bool PLayerIsNear()

        {
            float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
            return distanceToPlayer < 4f;
        }

        private void OpenTrapdoor()
        {
            gameObject.SetActive(false);
            prebaf.SetActive(true);
            isOpen = true;
        }
    }


