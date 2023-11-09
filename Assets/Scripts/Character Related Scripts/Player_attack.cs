using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    
    public Follow_Player enemy;
    private int damage;
    private Animation anim;
    private bool attack = false;
    public AnimacionKevin animacion;

    void Start()
    {
         anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
            Attack();
            
        }
        attack = false;
    }
    void Attack()
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
