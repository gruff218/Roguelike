using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public GameObject birdOriginal;

    // Start is called before the first frame update
    void Start()
    {
        CreateBirds(2);
    }

    void CreateBirds(int birdNum) {
        for (int i = 0; i < birdNum; i++) {
              GameObject birdClone = Instantiate(birdOriginal, new Vector3(birdOriginal.transform.position.x, i, birdOriginal.transform.position.y), birdOriginal.transform.rotation);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
