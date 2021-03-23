using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.gameObject);
        if (hitInfo.gameObject.layer == 9) {
            return;  
		}
        if (hitInfo.gameObject.name == "Player") {
              player.GetComponent<PlayerCombat>().TakeDamage(30);
		}
        Enemy e = hitInfo.GetComponent<Enemy>();
        if (e != null)
        {
            e.takeDamage(30);
        }
        Destroy(gameObject);




    }
    void OnCollisionEnter2D(Collision2D hitInfo) {
        //Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag == "Floor") {
            Object.Destroy(this.gameObject);
            return;  
		}
	}

}
