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
    public void WalkRigth(float movimentX)
    {
        animacion.SetFloat("walk", movimentX);
    }

    public void WalkLeft(float movimentX) 
    {
        animacion.SetFloat("walk",movimentX);
    }
    public void Atacar(bool attack)
    {
        animacion.SetBool("attack",attack);
    }
    public void IdlePlayer(bool idle)
    {
        animacion.SetBool("idle",idle);
    }

}
