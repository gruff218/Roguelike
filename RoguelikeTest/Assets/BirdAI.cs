using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BirdAI : MonoBehaviour
{

    
    Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float birdSize = 5f;

    public Transform enemyGFX;




    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

        
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        
        //Debug.Log(target.position.x);

        

        Vector2 direction = (target.GetComponent<Rigidbody2D>().position - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        

        if (force.x >= 0.01f) {
            enemyGFX.localScale = new Vector3(-birdSize, birdSize, birdSize);  
		} else if (force.x <= -0.01f) {
            enemyGFX.localScale = new Vector3(birdSize, birdSize, birdSize);  
		}
        
    }
}
