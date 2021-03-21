using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Enemy e = hitInfo.GetComponent<Enemy>();
        if (e != null)
        {
            e.takeDamage(30);
        }
        Destroy(gameObject);




    }
    void OnCollisionEnter2D(Collision2D hitInfo) {
        Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag == "Floor") {
            Object.Destroy(this.gameObject);
            return;  
		}
	}

}
