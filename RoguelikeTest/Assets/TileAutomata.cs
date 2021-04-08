using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System;

public class TileAutomata : MonoBehaviour
{
    private char[,] terrainMap;
    public Vector3Int tmapSize;
    public Tilemap map;
    public Tile tile;
    public GameObject opossum;
    public GameObject bird;
    int width;
    int height;
    private string[] array0 = new string[5];
    private string[] array1 = new string[5];
    private string[] array2 = new string[5];
    private string[] array3 = new string[5];
    private string[] array4 = new string[5];
    private string[] array5 = new string[5];
    private string[] array6 = new string[5];
    private readonly System.Random r = new System.Random();
    public Transform player;
    public int RandomNumber(int min, int max)
    {
        return r.Next(min, max);
    }
    public void doSim(int arrx, int arry, int type)
    {
        Queue<int> check = new Queue<int>();

        clearMap(false);
        width = tmapSize.x;
        height = tmapSize.y;
        if (terrainMap == null)
        {
            terrainMap = new char[width, height];
            for (int i = 0; i < 96; i++)
            {
                if (type == 2)
                {
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array2[0][i];
                    if (array2[0][i] == 'R')
                    {
                        if (RandomNumber(1, 6) == 2|RandomNumber(1,6)==3 | RandomNumber(1, 6) == 4)
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';

                        }
                        else
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
                            check.Enqueue(i);
                        }
                    }
                }
                if (type == 3)
                {
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array3[0][i];
                    if (array3[0][i] == 'R')
                    {
                        if (RandomNumber(1, 6) == 2 | RandomNumber(1, 6) == 3 | RandomNumber(1, 6) == 4)
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';

                        }
                        else
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
                            check.Enqueue(i);
                        }
                    }
                }
                if (type == 6)
                {
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array6[0][i];
                    if (array6[0][i] == 'R')
                    {
                        if (RandomNumber(1, 6) == 2 | RandomNumber(1, 6) == 3 | RandomNumber(1, 6) == 4)
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';

                        }
                        else
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
                            check.Enqueue(i);
                        }
                    }
                }
                if (type == 5)
                {
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array5[0][i];
                    if (array5[0][i] == 'R')
                    {
                        if (RandomNumber(1, 6) == 2 | RandomNumber(1, 6) == 3 | RandomNumber(1, 6) == 4)
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';

                        }
                        else
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
                            check.Enqueue(i);
                        }
                    }
                }
                if (type == 4)
                {
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array4[0][i];
                    if (array4[0][i] == 'R')
                    {
                        if (RandomNumber(1, 6) == 2 | RandomNumber(1, 6) == 3 | RandomNumber(1, 6) == 4)
                            {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';

                        }
                        else
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
                            check.Enqueue(i);
                        }
                    }
                }
                if (type == 1)
                {
                    int x = RandomNumber(0, 3);
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array1[x][i];
                    if (array1[0][i] == 'R')
                    {
                        if (RandomNumber(1, 6) == 2 | RandomNumber(1, 6) == 3 | RandomNumber(1, 6) == 4)
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';

                        }
                        else
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
                            check.Enqueue(i);
                        }
                    }
                }
                if (type == 0)
                {
                    int x = RandomNumber(0, 1);
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array0[x][i];
                    if (array0[0][i] == 'R')
                    {
                        if (RandomNumber(1, 6) == 2 | RandomNumber(1, 6) == 3 | RandomNumber(1, 6) == 4)
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';

                        }
                        else
                        {
                            terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
                            check.Enqueue(i);
                        }
                    }
                }
                if (type == 7)
                {

                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';
                }
                if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] == 'E') {
                    if (RandomNumber(1, 6) != 1) {
                        terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
					}        
				}
            }
        }

        while (check.Count != 0)
        {
            int i = check.Dequeue();
            if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] == 'O')
            {
                double count = 0;
                if (i % 12 == 0)
                {
                    count += 0.5;
                }
                else
                {
                    if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)) - 1, (int)(Math.Floor(i / 12.0))] == 'X')
                    {
                        count++;
                    }
                }
                if (i % 12 == 11)
                {
                    count += 0.5;
                }
                else
                {
                    if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)) + 1, (int)(Math.Floor(i / 12.0))] == 'X')
                    {
                        count++;
                    }
                }
                if (i < 12)
                {
                    count += 0.5;
                }
                else
                {
                    if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0)) - 1] == 'X')
                    {
                        count++;
                    }
                }
                if (i >= 84)
                {
                    count += 0.5;
                }
                else
                {
                    if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0)) + 1] == 'X')
                    {
                        count++;
                    }
                }
                if (count >= 3)
                {
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';
                    if (i % 12 != 0)
                    {
                        check.Enqueue(i - 1);
                    }
                    if (i % 12 != 11)
                    {
                        check.Enqueue(i + 1);
                    }
                    if (i >= 12)
                    {
                        check.Enqueue(i - 12);
                    }
                    if (i < 84)
                    {
                        check.Enqueue(i + 12);
                    }
                }
            }
        }
        int tcounter = 0;
        for (int i = 0; i< 96; i++)
        {
            if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] == 'X')
            {
                if (i % 12 != 0 & i % 12 != 11 & i >= 12 & i < 84)
                {
                    if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)) - 1, (int)(Math.Floor(i / 12.0))] == 'O' & terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)) + 1, (int)(Math.Floor(i / 12.0))] == 'O' & terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0)) - 1] == 'O' & terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0)) + 1] == 'O')
                    {
                        terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'O';
                        tcounter++;
                    }
                }
            }
        }
        //Debug.Log(tcounter);
        tcounter = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 'X')
                {
                    tcounter += arrx * 12 + x;
                    map.SetTile(new Vector3Int(arrx * 12 + x, -arry * 8 - y, 0), tile);
                }
                if (terrainMap[x, y] == 'E') {
                    Vector3 temp = new Vector3(0, 1, 0);
                    GameObject enemy = bird;
                    if (RandomNumber(1, 3) == 1) {
                        enemy = opossum;           
					}
                    
                    Instantiate(enemy, map.layoutGrid.CellToWorld(new Vector3Int(arrx * 12 + x, -arry * 8 - y, 0)) + temp, Quaternion.identity);
				}
            }
        }
        //Debug.Log(tcounter);

    }

    public void clearMap(bool complete)
    {

        terrainMap = null;
        if (complete)
        {
            map.ClearAllTiles();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        array1[0] = "RRRRRRRRRRRRRRRROOOOOOEOOOOOOOOOOORROOEOORROOOOOOOOORRRROOOOOOOXRRRRROOEOOXXXRRRRXXOXXXXXXXXXXXX";
        array1[1] = "XXRRORXOROXXXRROOEROORROOOROOEOOOOROOOOOOROOOOOOOOOOROOROOOOOOOXROOXROROEOXXOORXXOOOXXXXXXXXXXXX";
        array1[2] = "RRRRRRXXRRROORRRRROOEOOOOORRROOOOOEOOOOROOOROOOOOOOOOORROOOOEOOOOXRRRROOXOOOXXXRRRRRXXXXXXXXXXXX";
        array2[0] = "XXXOXRORXOXXXROOOROOROOXOROOOOOOOOEOOOOOOOOOOEOOOOOOROOXXROOXOOOXROOOOOORROOOOOOEOOXRXXOOORXOOXR";
        array3[0] = "XXOOOXRROOXXRROOOOOOOOOXROOOEOOOOOOOOOOOOEOOOOOOOOOXROROORROOOXXOOXROOOOOOROORXXREOOXXXXXXXXXXXX";
        array4[0] = "XXXROORXORXXXROOEOOROORXROXOOROOEORXOOOOOOORXOOOOOORXXOOOOOOXROOOEOOOOORXROOOOOOORRXXXRRXOOORXXX";
        array5[0] = "XXRRORXOROXXXRROEOROORROOOROOEOOOOROOOOOOROOOOOOOOOOROOROOOOOOOXROOXROROOOXXOORXXOOEXXXXXXXXXXXX";
        array6[0] = "XXRRORXOROXXXRROOOROORROOOROOOOOOOROOEOOOROOOOOOOOEOROOROOOOOOOXROOXROREOOXXOORXXOOOXXXXXXXXXXXX";
        array0[0] = "XXXRXXRXXXRXXRROOROORROXRREOOORORORXXOOOOOOOOOORXOOORORROOXXROEXOOOOOROXXORXXREOXRORXXRXXXRXXRXX";
        GenLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenLevel() {
        int[,] level = GetComponent<GenerateLevel>().GenLevel(5, 5);
        float startX = 0f;
        float startY = -10.5f;
        for (int row = 0; row < 5; row++)
        {
            string temp = "";
            for (int col = 0; col < 5; col++) {
                temp += (level[row, col] + " ");
                if (level[row, col] == 5) {
                    startX = 12*col + 18;
				}
            }
            Debug.Log(temp);
         } 
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (i == 0 || j == 0 || i == 6 || j == 6)
                {
                    doSim(i, j, 7);
                }
                else
                {
                    doSim(i, j, level[j - 1, i - 1]);
                }

            }
        }
        
        player.position = new Vector3(startX, startY, 0);
	}
}
