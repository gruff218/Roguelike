using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int bulletDamage = 20;
    public float bulletRate = 3f;
    float nextShootTime = 0f;

    public int maxHealth = 100;
    public float damageRate = 2f;
    float nextDamageTime = 0f;
    public int currentHealth;

    public float attackReach = 2f;

    public HealthBar healthBar;

    public float speed = 20f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    float powerBuffer = 100f;
    float nextPower = 0f;

    public GameManager gameManager;

    List<float> weakness = new List<float>();
    List<float> slowness = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime) {
            if (Input.GetButtonDown("Fire1")) {
                Attack();  
                nextAttackTime = Time.time + 1f/attackRate;
		    }
        }

        if (Time.time >= nextShootTime) {
            if (Input.GetButtonDown("Fire2")) {
                Shoot();
                nextShootTime = Time.time + 1f/bulletRate;
			}
		}
        
        if (weakness.Count > 0) {
            if (Time.time - weakness[0] > 5.0f) {
                weakness.Remove(weakness[0]); 
                Debug.Log("Weakness removed! Total amount: " + weakness.Count);
			}  
		}
        if (slowness.Count > 0) {
            GetComponent<PlayerMovement>().setSpeed(slowness.Count);
            if (Time.time - slowness[0] > 10.0f) {
                slowness.Remove(slowness[0]); 
                Debug.Log("Slowness removed! Total amount: " + slowness.Count);
			}  
		}
    }
        
    void Attack() {
        animator.SetTrigger("Attack");
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 current = new Vector2(transform.position.x, transform.position.y);
        Vector2 delta = target - current;
        if (delta.magnitude > attackReach) {
            
            delta.Normalize();
            delta = delta * attackReach;
            target = delta + current;
		}
        attackPoint.position = (Vector3)(target);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        int dmg = (int)(attackDamage * Math.Pow(0.5, weakness.Count));

        foreach(Collider2D enemy in hitEnemies) {
            if (!enemy.isTrigger){
                enemy.GetComponent<Enemy>().takeDamage(dmg);
			}
            
		}

	}
    void Shoot()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = target - myPos;
        direction.Normalize();
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void OnDrawGizmosSelected () {
        if (attackPoint == null) {
            return;  
		}
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}


    public void TakeDamage (int damage) {
        currentHealth -= damage;
        animator.SetInteger("Health", currentHealth);

        animator.SetTrigger("TakeDamage");

        Debug.Log("Just took " + damage + " damage");
        Debug.Log("Current health is now " + currentHealth);

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) {
            Die();  
		}
	}

    private void OnTriggerEnter2D(Collider2D enemy) {
        Debug.Log("called");
        if (Time.time >= nextPower) {
            if (enemy.tag == "AttackUp") {
                Debug.Log("Attack was boosted");
                attackDamage = attackDamage * 2;
                Destroy(enemy.gameObject);
                nextPower = Time.time + 1f/powerBuffer;
                return;
		    } else if (enemy.tag == "RangedUp") {
                Debug.Log("Ranged Damage was boosted");
                bulletDamage = bulletDamage * 2;
                Destroy(enemy.gameObject);
                nextPower = Time.time + 1f/powerBuffer;
                return;
		    } else if (enemy.tag == "AttackSpeedUp") {
                Debug.Log("Attack Speed was boosted");
                attackRate = attackRate * 2;
                Destroy(enemy.gameObject);
                nextPower = Time.time + 1f/powerBuffer;
                return;
		    } else if (enemy.tag == "RangedSpeedUp") {
                Debug.Log("Ranged Attack Speed was boosted");
                bulletRate = bulletRate * 2;
                Destroy(enemy.gameObject);
                nextPower = Time.time + 1f/powerBuffer;
                return;
		    }
            
        }
        if (enemy.isTrigger) {
            if (Time.time >= nextDamageTime) {
                int damage = 0;
                if (enemy.tag == "Bird" || enemy.tag == "Opossum" || enemy.tag == "Bullet") {
                    damage = 30;        
				}
                TakeDamage(damage);
                nextDamageTime = Time.time + 1f/damageRate;
			}
            
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag == "Bullet") {
              TakeDamage(30);
              Destroy(hitInfo.gameObject);
		}
        if (hitInfo.gameObject.tag == "Spell") {
            float spell = UnityEngine.Random.Range(0, 2);
            if (spell >= 1)
            {
                weakness.Add(Time.time);
                Debug.Log("Weakness added! Total amount: " + weakness.Count);
            } else {
                slowness.Add(Time.time);
                Debug.Log("Slowness added! Total amount: " + slowness.Count);
			}
            
            Destroy(hitInfo.gameObject);
            
		}
        
	}

    void Die() {
        Debug.Log("Died");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        this.enabled = false;
        gameManager.GetComponent<GameManager>().EndGame();
	}

    

}
