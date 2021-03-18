using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    //public GameObject bar;
    //GameObject player;


    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;


        fill.color = gradient.Evaluate(1f);
    }

    /*public void Start()
    {
        player = GameObject.Find("Player");
    }

    public void Update()
    {
        //Debug.Log(player.GetComponent<PlayerCombat>().currentHealth);
        if (player.GetComponent<PlayerCombat>().currentHealth == 100)
        {
            bar.GetComponent<Renderer>().enabled = false;
        } else if (player.GetComponent<PlayerCombat>().currentHealth < 100)
        {
            Debug.Log("hello");
            bar.SetActive(true);
        }
    }*/
}
