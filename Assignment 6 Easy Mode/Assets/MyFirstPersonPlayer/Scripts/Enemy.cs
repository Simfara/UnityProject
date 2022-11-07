/*
 * CIS 350 
 * Simfara Ranjit
 * Assignment6
 * Script that consists the behaviour for parent class Enemy
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected float speed;
    protected int health;

    //composition
    [SerializeField] protected Weapon weapon;

   //Maintain encapsulation?
    protected virtual void Awake()
    {
        //Using composition
        weapon = gameObject.AddComponent<Weapon>();
        speed = 5f;
        health = 100;

        weapon.damageBonus = 10;
    }

    protected abstract void Attack(int amount);
    public abstract void TakeDamage(int amount);
    // Update is called once per frame
    void Update()
    {
        
    }

}
