using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_AI : MonoBehaviour
{
    int dmg;
    int currentHealth;
    Rigidbody2D rb;
    Vector2 movement;
    //HealthBar healthBar;
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
        dmg = 30;
        player = GameObject.FindWithTag("Player").transform;
        bodyList = new List<GameObject>();
        /*animator.SetInteger("Health", currentHealth);*/
        rb = GetComponent<Rigidbody2D>();
        /*healthBar = transform.GetChild(1).GetChild(0).GetComponent<HealthBar>();
        healthBar.SetMaxHealth(currentHealth);*/
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        for (int i = 0; i < 10; i++)
        {
            GameObject body = Instantiate(wormbody, new Vector3(rb.transform.position.x, rb.transform.position.y - i - 1, rb.transform.position.y), rb.transform.rotation);
            bodyList.Add(body);
        }
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage");
        Debug.Log("Current health is " + currentHealth);



    }
    void Update()
    {
        /*animator.SetFloat("Velocity", rb.velocity.magnitude);*/
        getDistance(rb.transform);
        Vector3 target = player.position;
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (rb.rotation >= 360)
        {
            rb.rotation -= 360;
        }
        if (rb.rotation < 0)
        {
            rb.rotation += 360;
        }
        while (angle > 360)
        {
            angle = angle - 360;
        }
        if (angle < 0 || angle == 360)
        {
            angle = 360 + angle;
        }
        float angle2 = rb.rotation;
        while (angle2 > 360)
        {
            angle2 = angle2 - 360;
        }

        if (angle2 < 0 || angle2 == 360)
        {
            angle2 = 360 + angle2;
        }
        float nangle = angle2 - angle;
        if (nangle > 180)
        {
            rb.rotation += 1;
        }
        else if (nangle < -180)
        {
            rb.rotation -= 1;
        }
        else if (nangle < -1)
        {
            rb.rotation += 1;
        }
        else if (nangle > 1)
        {
            rb.rotation -= 1;
        }
        else
        {
            rb.rotation = angle;
        }
        float fangle = rb.rotation*Mathf.Deg2Rad;
        Debug.Log(angle+" "+angle2+" "+nangle);
        Debug.Log(Mathf.Cos(fangle) + " " + Mathf.Sin(fangle)+" "+rb.rotation);
        direction = new Vector3(Mathf.Cos(fangle), Mathf.Sin(fangle), 0.0f);
        rb.MovePosition((Vector2)transform.position + (Vector2)(direction * 25 * Time.deltaTime));
        Vector3 prevposition = rb.transform.position;
        int currenthealth = currentHealth;
        for (int i = 0; i<10; i++)
        {
            GameObject body = bodyList[i];
            currenthealth += body.GetComponent<Boss>().getHealth();
            Vector3 fix = new Vector3(0.0f, 0.0f, 0.0f - body.transform.position.z);
            body.transform.Translate(fix);
            Rigidbody2D wormrb = body.GetComponent<Rigidbody2D>();
            target = prevposition;
            prevposition = wormrb.position;
            Vector3 pos = new Vector3(wormrb.position.x, wormrb.position.y);
            Vector3 dir = target - pos;
            //wormrb.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            wormrb.transform.up = dir;
            target = target - (wormrb.transform.up * 0.5f);
            float dist = (target - pos).magnitude;
            //Debug.Log(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            wormrb.position = Vector3.MoveTowards(pos, target, Mathf.Lerp(0.0f, dist, dist / 1f));
            getDistance(body.transform);
        }
        if (currenthealth<=0)
        {
            while (bodyList.Count>0)
            {
                GameObject body = bodyList[0];
                bodyList.RemoveAt(0);
                body.GetComponent<Boss>().Die();
            }
            Die();
        }
        Debug.Log(currenthealth);
    }
    private void getDistance(Transform worm)
    {
        if (Vector3.Distance(player.position,worm.position)<1.0f)
        {
            player.GetComponent<PlayerCombat>().TakeDamage(dmg);
        }
    }
    void Die()
    {


        Collider2D[] colliders;
        colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)


            GetComponent<Rigidbody2D>().gravityScale = 1;
        this.enabled = false;



    }
    public int getHealth()
    {
        return currentHealth;
    }
}