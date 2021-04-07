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
                        if (RandomNumber(1, 3) == 2)
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
                        if (RandomNumber(1, 3) == 2)
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
                        if (RandomNumber(1, 3) == 2)
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
                        if (RandomNumber(1, 3) == 2)
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
                        if (RandomNumber(1, 3) == 2)
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
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array1[0][i];
                    if (array1[0][i] == 'R')
                    {
                        if (RandomNumber(1, 3) == 2)
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
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = array0[0][i];
                    if (array0[0][i] == 'R')
                    {
                        if (RandomNumber(1, 3) == 2)
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
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 'X')
                {
                    tcounter += arrx * 12 + x;
                    map.SetTile(new Vector3Int(arrx * 12 + x, -arry * 8 - y, 0), tile);
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
        array1[0] = "RRRRRRRRRRRRRRRROOOOOOOOOOOOOOOOOORROOOOORROOOOOOOOORRRROOOOOOOXRRRRROOOOOXXXRRRRXXOXXXXXXXXXXXX";
        array1[1] = "XXRRORXOROXXXRROOOROORROOOROOOOOOOROOOOOOROOOOOOOOOOROOROOOOOOOXROOXROROOOXXOORXXOOOXXXXXXXXXXXX";
        array2[0] = "XXXOXRORXOXXXROOOROOROOXOROOOOOOOOOOOOOOOOOOOOOOOOOOROOXXROOXOOOXROOOOOORROOOOOOOOOXRXXOOORXOOXR";
        array3[0] = "XXOOOXRROOXXRROOOOOOOOOXROOOOOOOOOOOOOOOOOOOOOOOOOOXROROORROOOXXOOXROOOOOOROORXXROOOXXXXXXXXXXXX";
        array4[0] = "XXXROORXORXXXROOOOOROORXROXOOROOOORXOOOOOOORXOOOOOORXXOOOOOOXROOOOOOOOORXROOOOOOORRXXXRRXOOORXXX";
        array5[0] = "XXRRORXOROXXXRROOOROORROOOROOOOOOOROOOOOOROOOOOOOOOOROOROOOOOOOXROOXROROOOXXOORXXOOOXXXXXXXXXXXX";
        array6[0] = "XXRRORXOROXXXRROOOROORROOOROOOOOOOROOOOOOROOOOOOOOOOROOROOOOOOOXROOXROROOOXXOORXXOOOXXXXXXXXXXXX";
        array0[0] = "XXXRXXRXXXRXXRROOROORROXRROOOORORORXXOOOOOOOOOORXOOORORROOXXROOXOOOOOROXXORXXROOXRORXXRXXXRXXRXX";
        GenLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenLevel() {
        int[,] level = GetComponent<GenerateLevel>().GenLevel(5, 5);
        for (int row = 0; row < 5; row++)
        {
            string temp = "";
            for (int col = 0; col < 5; col++)               
                temp += (level[row, col] + " ");
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
	}
}
