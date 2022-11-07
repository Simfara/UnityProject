/*
 * CIS 350 
 * Simfara Ranjit
 * Assignment6
 * Script thats uses polymorphism 
 */
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damageBonus;

    public Enemy enemyHoldingWeapon;

    private void Awake()
    {
        enemyHoldingWeapon = gameObject.GetComponent<Enemy>();
        EnemyEatsWeapon(enemyHoldingWeapon); //Polymorphism
    }
      
    //Polymorphism
    protected void EnemyEatsWeapon( Enemy enemy)
    {
        Debug.Log("Enemy eats Weapon??");
    }
    public void Recharge()
    {
        Debug.Log("Recharging Weapon!");
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
