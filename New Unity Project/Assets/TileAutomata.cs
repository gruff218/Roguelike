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
    public Tile rTile;
    public Tile eTile;
    int width;
    int height;
    private string[] array = new string[5];
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
                terrainMap[i - 12*(int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))]= array[0][i];
                if (array[0][i]=='R')
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
        }

        while (check.Count != 0)
        {
            int i = check.Dequeue();
            if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))]=='O')
            {
                double count = 0;
                if (i%12==0)
                {
                    count += 0.5;
                }
                else
                {
                    if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0))-1, (int)(Math.Floor(i / 12.0))] == 'X')
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
                if (i <12)
                {
                    count += 0.5;
                }
                else
                {
                    if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))-1] == 'X')
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
                    if (terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))+1] == 'X')
                    {
                        count++;
                    }
                }
                if (count>=3)
                {
                    terrainMap[i - 12 * (int)(Math.Floor(i / 12.0)), (int)(Math.Floor(i / 12.0))] = 'X';
                    if (i%12!=0)
                    {
                        check.Enqueue(i - 1);
                    }
                    if (i%12!=11)
                    {
                        check.Enqueue(i + 1);
                    }
                    if (i>=12)
                    {
                        check.Enqueue(i - 12);
                    }
                    if (i<84)
                    {
                        check.Enqueue(i + 12);
                    }
                }
            }
        }
        int tcounter = 0;
        for (int x = 0; x<width;x++)
        {
            for (int y = 0; y<height;y++)
            {
                if (terrainMap[x,y]=='X')
                {
                    tcounter += arrx * 12 + x;
                    map.SetTile(new Vector3Int(arrx*12+x, -arry*8-y, 0), tile);
                }
                if (terrainMap[x, y] == 'O')
                {
                    tcounter+=arrx*12+x;
                    map.SetTile(new Vector3Int(arrx*12+x, -arry*8-y, 0), eTile);
                }
            }
        }
        Debug.Log(tcounter);
        
    }

    public void clearMap(bool complete)
    {
        map.ClearAllTiles();
        if (complete)
        {
            terrainMap = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        array[0] = "RRRRRRRRRRRRRRRROOOOOOOOOOOOOOOOOORROOOOORROOOOOOOOORRRROOOOOOOXRRRRROOOOOXXXRRRRXXOXXXXXXXXXXXX";
        doSim(0,0,2);
        doSim(1, 0, 2);
        doSim(0, 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
