using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    
    public Follow_Player enemy;
    public int damage;
    public Transform attackCheck;
    public float radiusAttack;
    public LayerMask layerEnemy;
    float timeNextAttack;
    public float radius;

    void Start()
    {
        damage = 20;
    }

    // Update is called once per frame
    void Update()
    {
    }

 
    
}
