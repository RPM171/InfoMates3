using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : MonoBehaviour
{
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("SceneManager").GetComponent<Scenes>().EscenaJugar();
        }
    }
}
