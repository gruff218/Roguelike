using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player") {
            return;  
		}
        if (hitInfo.gameObject.layer == 9)
        {
            Enemy e = hitInfo.GetComponent<Enemy>();
            if (e != null)
            {
                e.takeDamage(player.GetComponent<PlayerCombat>().bulletDamage);
            }
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.layer == 12) 
        {
            Boss e = hitInfo.GetComponent<Boss>();
            if (e != null)
            {
                e.takeDamage(player.GetComponent<PlayerCombat>().bulletDamage);
            }
            Destroy(gameObject);
        }




    }
    void OnCollisionEnter2D(Collision2D hitInfo) {
        //Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag == "Floor") {
            Object.Destroy(this.gameObject);
            return;  
		}
	}

}
