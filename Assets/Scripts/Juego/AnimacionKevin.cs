using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionKevin : MonoBehaviour
{
    public Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void WalkRigth(bool Walk)
    {
        animacion.SetBool("WalkLeft", Walk);
    }

    public void WalkLeft(bool Walk) 
    {
        animacion.SetBool("WalkRigth", Walk);
    }
    public void Atacar(bool attack)
    {
        animacion.SetBool("attack",attack);
    }
    public void Idle(bool idle)
    {
        animacion.SetBool("idle", idle);
    }

}
