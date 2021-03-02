using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGraphics : MonoBehaviour
{

    public AIPath aiPath;
    public float birdSize = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f) {
            transform.localScale = new Vector3(-birdSize, birdSize, birdSize);  
		} else if (aiPath.desiredVelocity.x <= -0.01f) {
            transform.localScale = new Vector3(birdSize, birdSize, birdSize);  
		}
    }
}
