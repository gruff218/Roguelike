using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour
{
    public Text display;
    public int level;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLevel(int num) {
        level = num;
        display.text = "Level: " + level;
	}
}
