using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int maxHealth = 100;
    public float damageRate = 2f;
    float nextDamageTime = 0f;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Attack();  
                nextAttackTime = Time.time + 1f/attackRate;
		    }
        }
        
    }

    void Attack() {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        

        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
		}

        


	}

    void OnDrawGizmosSelected () {
        if (attackPoint == null) {
            return;  
		}
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}


    void TakeDamage (int damage) {
        currentHealth -= damage;
        animator.SetInteger("Health", currentHealth);

        animator.SetTrigger("TakeDamage");

        Debug.Log("Just took " + damage + " damage");
        Debug.Log("Current health is now " + currentHealth);

        if (currentHealth <= 0) {
            Die();  
		}
	}

    private void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.isTrigger) {
            if (Time.time >= nextDamageTime) {
                int damage = 0;
                if (enemy.tag == "Bird") {
                    damage = 30;        
				}
                TakeDamage(damage);
                nextDamageTime = Time.time + 1f/damageRate;
			}
            
        }
    }

    void Die() {
    Debug.Log("Died");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        this.enabled = false;
	}
}
