using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class OpossumAI : MonoBehaviour
{

    
    public float speed = 200f;
    public float size = 5f;

    public Transform enemyGFX;
    Transform player;

    public GameObject bullet;
    public float bulletSpeed = 15f;
    public float shootSpeed;
    float timeNextShot;


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        timeNextShot = shootSpeed;

        
    }





    void Update() {
        if (timeNextShot <= 0) {
            Vector2 target = new Vector2(player.position.x, player.position.y);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            GameObject curBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            curBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            timeNextShot = shootSpeed;
		} else {
            timeNextShot -= Time.deltaTime;  
		}
	}

    // Update is called once per frame
    void FixedUpdate()
    {

  
        float direction = (player.position.x - rb.position.x)/(Mathf.Abs(player.position.x - rb.position.x));
        Vector2 force = new Vector2(4.0f * direction, 2f);
        if (Mathf.Abs(player.position.x - rb.position.x) > 1) {
            rb.AddForce(force * speed * Time.deltaTime);
		}


        

        if (force.x >= 0.01f) {
            enemyGFX.localScale = new Vector3(-size, size, size);  
		} else if (force.x <= -0.01f) {
            enemyGFX.localScale = new Vector3(size, size, size);  
		}
        
    }
}
