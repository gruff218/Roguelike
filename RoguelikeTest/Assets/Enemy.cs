using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int maxHealth = 100;
    public Animator animator;
    int currentHealth;

    Rigidbody2D rb;

    HealthBar healthBar;
    public GameObject attackUp;
    public GameObject attackSpeedUp;
    public GameObject rangedUp;
    public GameObject rangedSpeedUp;

    // Start is called before the first frame update
    void Start()
    {
        int level = GameInfo.level;
        maxHealth = maxHealth * (1 + level/10);
        currentHealth = maxHealth;
        animator.SetInteger("Health", currentHealth);
        rb = GetComponent<Rigidbody2D>();
        healthBar = transform.GetChild(1).GetChild(0).GetComponent<HealthBar>();
        healthBar.SetMaxHealth(currentHealth);

        /*attackUp = GameObject.FindWithTag("AttackUp");
        rangedUp = GameObject.FindWithTag("RangedUp");
        attackSpeedUp = GameObject.FindWithTag("AttackSpeedUp");
        rangedSpeedUp = GameObject.FindWithTag("RangedSpeedUp");
        Debug.Log(rangedSpeedUp.tag);*/
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        animator.SetInteger("Health", currentHealth);

        animator.SetTrigger("TakeDamage");

        Debug.Log("Enemy took " + damage + " damage");
        Debug.Log("Current health is " + currentHealth);

        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0) {
            Die();  
		}
	}

    void Die() {

        int rand = Random.Range(0, 4);
        GameObject powerUp = null;
        if (rand == 0) {
            powerUp = attackUp;
		} else if (rand == 1) {
            powerUp = rangedUp;
		} else if (rand == 2) {
            powerUp = attackSpeedUp;
		} else if (rand == 3) {
            powerUp = rangedSpeedUp;
		}

        Debug.Log(rand);
        Instantiate(powerUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        Collider2D[] colliders;
        colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders) {
            collider.enabled = false;  
		}
        if (this.name == "Bird") {
            GetComponent<BirdAI>().enabled = false;
		} else if (this.name == "Opossum") {
            GetComponent<OpossumAI>().enabled = false;
		}
        
        GetComponent<Rigidbody2D>().gravityScale = 1;
        this.enabled = false;

        Destroy(this.gameObject, 0.5f);

	}
    
    void Update() {
        animator.SetFloat("Velocity", rb.velocity.magnitude);
	}

    public int getHealth() {
        return currentHealth;
	}
}