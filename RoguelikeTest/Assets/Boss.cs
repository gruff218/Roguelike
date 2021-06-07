using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{


    public int maxHealth = 100;
    int currentHealth;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        /*attackUp = GameObject.FindWithTag("AttackUp");
        rangedUp = GameObject.FindWithTag("RangedUp");
        attackSpeedUp = GameObject.FindWithTag("AttackSpeedUp");
        rangedSpeedUp = GameObject.FindWithTag("RangedSpeedUp");
        Debug.Log(rangedSpeedUp.tag);*/
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage");
        Debug.Log("Current health is " + currentHealth);



    }

    public void Die()
    {


        Collider2D[] colliders;
        colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)


        GetComponent<Rigidbody2D>().gravityScale = 1;
        this.enabled = false;



    }

    void Update()
    {
    }

    public int getHealth()
    {
        return currentHealth;
    }
}