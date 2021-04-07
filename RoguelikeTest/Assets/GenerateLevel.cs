using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{

    int prevTileType = 0;
    // Start is called before the first frame update
    void Start()
    {
        GenLevel(5, 5);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[,] GenLevel(int gridX, int gridY) {
        int[,] level = new int[gridY, gridX];
        
        
        int y = 0;
        int x = Random.Range(0, gridX);
        level[0, x] = 1;
        int startX = x;
        int startY = y;

        int dir = 0;

        //Debug.Log("Start at pos: " + x);

        

        //Debug.Log(getPos(7, gridX, gridY)[0] + " " + getPos(7, gridX, gridY)[1]);
        while(y * gridX + x < gridX * gridY) {
            if (x < 0) {
                level[y, 0] = 2;
                
                x = 0;
                prevTileType = 2;
                dir = 0;
                if (y > 0) {
                    if (level[y - 1, 0] == 2 || level[y - 1, 0] == 4) {
                        level[y, 0] = 4;
                        prevTileType = 4;
					}
				}
                //Debug.Log(x + ", " + y + "  52");
                y++;
			} else if (x >= gridX) {
                level[y, gridX - 1] = 2;
                
                x = gridX - 1;
                prevTileType = 2;
                dir = 0;
                if (y > 0) {
                    if (level[y - 1, x] == 2 || level[y - 1, x] == 4) {
                        level[y, x] = 4;
                        prevTileType = 4;
					}
				}
                //Debug.Log(x + ", " + y + "  65");
                y++;
			} else {
                
                if (dir == 0) {
                    level[y, x] = 3;
                    prevTileType = 3;
                    int rand = Random.Range(0, 5);
                
                    if (rand <= 1) {
                        dir = 1;
			        } else if (rand <= 3) {
                        dir = -1;
			        } else {
                        dir = 0;        
			    	}

                    if ((x + dir < 0 || x + dir >= gridX) && rand % 2 == 0) {
                        dir = dir * -1;           
					}
                    
                    
			    } else {
                    level[y, x] = 1;
                    prevTileType = 1;
                    int rand = Random.Range(0, 4);
                    if (rand == 0) {
                        dir = 0;        
			    	}
			    }

                if (dir == 0) {
                    //Debug.Log(prevTileType);
                    if (prevTileType == 3 || prevTileType == 4 || prevTileType == 2) {
                        level[y, x] = 4;
                        prevTileType = 4;
                        y += 1;
					} else {
                        level[y, x] = 2;
                        prevTileType = 2;
                        y += 1;
                        //Debug.Log(x + ", " + y);
                    }
			    }

                x += dir;
            }
            
            
            
		}

        level[startY, startX] = 5;
        if (x < 0) {
            x = 0;  
		} else if (x >= gridX) {
            x = gridX - 1;  
		}
        if (y >= gridY) {
            y = gridY - 1;  
		}
        level[y, x] = 6;
        
        for (int row = 0; row < gridY; row++)
        {
            string temp = "";
            for (int col = 0; col < gridX; col++)               
                temp += (level[row, col] + " ");
            //Debug.Log(temp);
         } 

         return level;
	}

    int[] getPos(int pointer, int gridX, int gridY) {
        int x = pointer % gridY;
        int y = (pointer - x)/gridX;

        int[] ret = new int[2] {y, x};

        return ret;
	}
}
