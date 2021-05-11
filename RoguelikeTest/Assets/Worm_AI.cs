using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_AI : MonoBehaviour
{


    public int maxHealth = 100;

    int currentHealth;

    Rigidbody2D rb;
    Vector2 movement;
    HealthBar healthBar;
    /*public Animator animator;
    public GameObject attackUp;
    public GameObject attackSpeedUp;
    public GameObject rangedUp;
    public GameObject rangedSpeedUp;*/
    Transform player;
    public GameObject wormbody;
    public GameObject wormhead;
    public List<GameObject> bodyList;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        bodyList = new List<GameObject>();
        currentHealth = maxHealth;
        /*animator.SetInteger("Health", currentHealth);*/
        rb = GetComponent<Rigidbody2D>();
        /*healthBar = transform.GetChild(1).GetChild(0).GetComponent<HealthBar>();
        healthBar.SetMaxHealth(currentHealth);*/
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        for (int i = 0; i < 10; i++)
        {
            GameObject body = Instantiate(wormbody, new Vector3(rb.transform.position.x, rb.transform.position.y-i-1, rb.transform.position.y), rb.transform.rotation);
            bodyList.Add(body);
        }
        /*attackUp = GameObject.FindWithTag("AttackUp");
        rangedUp = GameObject.FindWithTag("RangedUp");
        attackSpeedUp = GameObject.FindWithTag("AttackSpeedUp");
        rangedSpeedUp = GameObject.FindWithTag("RangedSpeedUp");
        Debug.Log(rangedSpeedUp.tag);*/
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        /*animator.SetInteger("Health", currentHealth);

        animator.SetTrigger("TakeDamage");*/

        Debug.Log("Enemy took " + damage + " damage");
        Debug.Log("Current health is " + currentHealth);

        /*healthBar.SetHealth(currentHealth);*/


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        int rand = Random.Range(0, 4);
        GameObject powerUp = null;
        /*if (rand == 0) {
            powerUp = attackUp;
		} else if (rand == 1) {
            powerUp = rangedUp;
		} else if (rand == 2) {
            powerUp = attackSpeedUp;
		} else if (rand == 3) {
            powerUp = rangedSpeedUp;
		}*/

        Debug.Log(rand);
        Instantiate(powerUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        Collider2D[] colliders;
        colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
        if (this.name == "Bird")
        {
            GetComponent<BirdAI>().enabled = false;
        }
        else if (this.name == "Opossum")
        {
            GetComponent<OpossumAI>().enabled = false;
        }

        GetComponent<Rigidbody2D>().gravityScale = 1;
        this.enabled = false;



    }

    void Update()
    {
        /*animator.SetFloat("Velocity", rb.velocity.magnitude);*/
        Vector3 target = player.position;
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (rb.rotation >= 360)
        {
            rb.rotation -= 360;
        }
        if (rb.rotation <= 360)
        {
            rb.rotation += 360;
        }
        while (angle > 360)
        {
            angle = angle - 360;
        }
        if (angle<0||angle==360)
        {
            angle = 360 + angle;
        }
        float angle2 = rb.rotation;
        while (angle2>360)
        {
            angle2 = angle2 - 360;
        }
           
        if (angle2<0||angle2==360)
        {
            angle2 = 360 + angle2;
        }
        float nangle = angle2 - angle;
        if (nangle>180)
        {
            rb.rotation += 1;
        }
        else if (nangle <-180)
        {
            rb.rotation -= 1;
        }
        else if (nangle<-1)
        {
            rb.rotation += 1;
        }
        else if (nangle>1)
        {
            rb.rotation -= 1;
        }
        else
        {
            rb.rotation = angle;
        }
        float fangle = rb.rotation*Mathf.Deg2Rad;
        //Debug.Log(angle+" "+angle2+" "+nangle);
        Debug.Log(Mathf.Cos(fangle) + " " + Mathf.Sin(fangle)+" "+rb.rotation);
        direction = new Vector3(Mathf.Cos(fangle), Mathf.Sin(fangle), 0.0f);
        rb.MovePosition((Vector2)transform.position + (Vector2)(direction * 25 * Time.deltaTime));
        Vector3 prevposition = rb.transform.position;
        for (int i = 0; i<10; i++)
        {
            GameObject body = bodyList[i];
            Rigidbody wormrb = body.GetComponent<Rigidbody>();
            target = prevposition;
            prevposition = wormrb.position;
            wormrb.rotation = Quaternion.LookRotation(Vector3.forward, (target - wormrb.position).normalized);
            target = target - (wormrb.transform.up * 0.5f);
            float dist = (target - wormrb.position).magnitude;
            wormrb.position = Vector3.MoveTowards(wormrb.position, target, Mathf.Lerp(0.0f, dist, dist / 1f));
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }
}