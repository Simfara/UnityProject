using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Golem inherits from Enemy
public class Golem : Enemy
{
    protected int damage;


    protected override void Awake()
    {
        base.Awake();
        health = 120;
        //GameManager.score = 5;
        GameManager.instance.score +=2;
    }

    protected override void Attack(int amount)
    {
        Debug.Log("Golem Attacks!");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("You took" + amount + " points of damage");
    }
}
