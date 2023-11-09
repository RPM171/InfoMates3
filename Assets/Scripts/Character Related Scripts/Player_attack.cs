using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    
    public Follow_Player enemy;
    private int damage;
    public AnimacionKevin animacion;

    void Start()
    {
         animacion = GetComponent<AnimacionKevin>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Attack(bool attack)
    {
        animacion.Atacar(attack);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.setHealthEnemy(damage);


        }
    }

}
