using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;

public class Player_attack : MonoBehaviour
{

    [SerializeField] private Follow_Player enemy;
    [SerializeField] private int damage;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float radiusAttack;
    private Animator animator;
    public LayerMask layerEnemy;
    [SerializeField] private float timeNextAttack;
    [SerializeField] private float timeIdle;

    private void Start()
    {
        animator = GetComponent<Animator>();   
    }
    private void Update()
    {
        if (timeNextAttack > 0)
        {
            timeNextAttack -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& timeNextAttack <=0)
        {
            animator.SetTrigger("attack");
            
            timeNextAttack = timeIdle;
        }
    }

    private void Attack()
    {
        Collider2D[] objeto = Physics2D.OverlapCircleAll(attackCheck.position, radiusAttack);
        foreach (Collider2D collision in objeto)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.transform.GetComponent<Follow_Player>().setHealthEnemy(damage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;    
        Gizmos.DrawWireSphere(attackCheck.position, radiusAttack);
    }


}
