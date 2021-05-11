using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public bool stop;
    public GameObject birdOriginal;
    public GameObject opossumOriginal;
    public GameObject worm;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        stop = false;
        //CreateBirds(2);
        //CreateOpossums(1);
    }

    void CreateBirds(int birdNum) {
        for (int i = 0; i < birdNum; i++) {
              GameObject birdClone = Instantiate(birdOriginal, new Vector3(birdOriginal.transform.position.x, i, birdOriginal.transform.position.y), birdOriginal.transform.rotation);
		}
	}

    void CreateOpossums(int num) {
        for (int i = 0; i < num; i++) {
              GameObject clone = Instantiate(opossumOriginal, new Vector3(opossumOriginal.transform.position.x, i, opossumOriginal.transform.position.y), opossumOriginal.transform.rotation);
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (player.position.y<-50&&!stop)
        {
            stop = true;
            GameObject wormClone2 = Instantiate(worm, new Vector3(worm.transform.position.x+20, worm.transform.position.y - 50.0f, 0.0f), worm.transform.rotation);
            GameObject wormClone1 = Instantiate(worm, new Vector3(worm.transform.position.x-20, worm.transform.position.y - 50.0f, 0.0f), worm.transform.rotation);
        }
    }
}
