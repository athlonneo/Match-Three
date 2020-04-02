using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int gridSizeX, gridSizeY;
    public GameObject tilePrefab;
    public GameObject[] candies;
    public GameObject[,] tiles;
    void Start()
    {
        CreateGrid();
    }
    void CreateGrid()
    {
        Vector2 offset = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        Vector2 startPos = transform.position + (Vector3.left * (offset.x * gridSizeX / 2)) + (Vector3.down * (offset.y * gridSizeY / 3));

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                //Debug.Log(x + ", " + y);
                Vector2 pos = new Vector3(startPos.x + (x * offset.x), startPos.y + (y * offset.y));
                GameObject backgroundTile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation);
                backgroundTile.transform.parent = transform;
                backgroundTile.name = "(" + x + "," + y + ")";

                int index = Random.Range(0, candies.Length);
                GameObject candy = Instantiate(candies[index], pos, Quaternion.identity);
                //candy.GetComponent<Tile>().Init();
                candy.name = "(" + x + "," + y + ")";
                //tiles[x, y] = candy;
            }
        }
    }
}