using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void controls()
    {
        GameObject.Find("SceneManager").GetComponent<Scenes>().Controles();
    }
}
