using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int maxHealth = 100;
    public Animator animator;
    int currentHealth;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator.SetInteger("Health", currentHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        animator.SetInteger("Health", currentHealth);

        animator.SetTrigger("TakeDamage");

        Debug.Log("Enemy took " + damage + " damage");
        Debug.Log("Current health is " + currentHealth);


        if (currentHealth <= 0) {
            Die();  
		}
	}

    void Die() {
        GetComponent<Collider2D>().enabled = false;
        if (this.name == "Bird") {
            GetComponent<BirdAI>().enabled = false;
		} else if (this.name == "Opoussum") {
            GetComponent<OpossumAI>().enabled = false;
		}
        
        GetComponent<Rigidbody2D>().gravityScale = 1;
        this.enabled = false;
	}
    
    void Update() {
        animator.SetFloat("Velocity", rb.velocity.magnitude);
	}
}