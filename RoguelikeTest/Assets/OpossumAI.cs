using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class OpossumAI : MonoBehaviour
{

    
    public Transform target;
    public float speed = 200f;
    public float size = 5f;

    public Transform enemyGFX;

    public GameObject bullet;

    public float shootSpeed;
    float timeNextShot;


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        timeNextShot = shootSpeed;

        
    }





    void Update() {
        if (timeNextShot <= 0) {
              Instantiate(bullet, transform.position, Quaternion.identity);
              timeNextShot = shootSpeed;
		} else {
            timeNextShot -= Time.deltaTime;  
		}
	}

    // Update is called once per frame
    void FixedUpdate()
    {

  
        float direction = (target.position.x - rb.position.x)/(Mathf.Abs(target.position.x - rb.position.x));
        Vector2 force = new Vector2(4.0f * direction, 2f);
        if (Mathf.Abs(target.position.x - rb.position.x) > 1) {
            rb.AddForce(force * speed * Time.deltaTime);
		}


        

        if (force.x >= 0.01f) {
            enemyGFX.localScale = new Vector3(-size, size, size);  
		} else if (force.x <= -0.01f) {
            enemyGFX.localScale = new Vector3(size, size, size);  
		}
        
    }
}
