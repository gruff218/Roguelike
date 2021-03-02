using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.isTrigger) {
            Debug.Log(enemy.name);
        }
    }
}
