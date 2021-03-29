using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        GenLevel(5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenLevel(int gridX, int gridY) {
        int[,] level = new int[gridY, gridX];
        
        level[0, 0] = 1;
        int y = 0;
        int x = 1;

        int dir = 1;

        //Debug.Log(getPos(7, gridX, gridY)[0] + " " + getPos(7, gridX, gridY)[1]);
        while(y * gridX + x < gridX * gridY) {

            
            if (x < 0) {
                level[y, 0] = 2;
                y++;
                x = 0;
			} else if (x >= gridX) {
                level[y, gridX - 1] = 2;
                y++;
                x = gridX - 1;
			}
            int rand = Random.Range(0, 5);
            
            if (rand <= 1) {
                level[y, x] = 1;
			} else if (rand <= 3) {
                level[y, x] = 1;
			}
		}

	}

    int[] getPos(int pointer, int gridX, int gridY) {
        int x = pointer % gridY;
        int y = (pointer - x)/gridX;

        int[] ret = new int[2] {y, x};

        return ret;
	}
}
