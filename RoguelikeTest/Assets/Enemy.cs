using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int maxHealth = 100;
    public Animator animator;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator.SetInteger("Health", currentHealth);
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        animator.SetInteger("Health", currentHealth);

        animator.SetTrigger("TakeDamage");


        if (currentHealth <= 0) {
            Die();  
		}
	}

    void Die() {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        this.enabled = false;
	}
    
}