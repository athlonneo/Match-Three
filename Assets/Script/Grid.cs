using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int gridSizeX, gridSizeY;
    public GameObject tilePrefab;
    public GameObject[] candies;
    public GameObject[,] tiles;

    public Vector2 startPosition;
    public Vector2 offset;

    void Start()
    {
        tiles = new GameObject[gridSizeX, gridSizeY];
        CreateGrid();
    }
    void CreateGrid()
    {
        offset = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        startPosition = transform.position + (Vector3.left * (offset.x * gridSizeX / 2)) + (Vector3.down * (offset.y * gridSizeY / 3));

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                //Debug.Log(x + ", " + y);
                Vector2 pos = new Vector3(startPosition.x + (x * offset.x), startPosition.y + (y * offset.y));
                GameObject backgroundTile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation);
                backgroundTile.transform.parent = transform;
                backgroundTile.name = "(" + x + "," + y + ")";

                int index = Random.Range(0, candies.Length);
                int MAX_ITERATION = 0;
                while (MatchesAt(x, y, candies[index]) && MAX_ITERATION < 100)
                {
                    index = Random.Range(0, candies.Length);
                    MAX_ITERATION++;
                }
                MAX_ITERATION = 0;

                GameObject candy = Instantiate(candies[index], pos, Quaternion.identity) ;
                //candy.GetComponent<Tile>().Init();
                candy.name = "(" + x + "," + y + ")";
                //Debug.Log(tiles);
                tiles[x, y] = candy.gameObject;
            }
        }
    }

    private bool MatchesAt(int column, int row, GameObject piece)
    {
        if (column > 1 && row > 1)
        {
            if (tiles[column - 1, row].tag == piece.tag && tiles[column - 2, row].tag == piece.tag)
            {
                return true;
            }
            if (tiles[column, row - 1].tag == piece.tag && tiles[column, row - 2].tag == piece.tag)
            {
                return true;
            }
        }
        else if (column <= 1 || row <= 1)
        {
            if (row > 1)
            {
                if (tiles[column, row - 1].tag == piece.tag && tiles[column, row - 2].tag == piece.tag)
                {
                    return true;
                }
            }
            if (column > 1)
            {
                if (tiles[column - 1, row].tag == piece.tag && tiles[column - 2, row].tag == piece.tag)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void DestroyMatchesAt(int column, int row)
    {

        if (tiles[column, row].GetComponent<Tile>().isMatched)
        {
            Destroy(tiles[column, row]);
            tiles[column, row] = null;
        }
    }

    public void DestroyMatches()
    {
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                if (tiles[i, j] != null)
                {
                    DestroyMatchesAt(i, j);
                }
            }
        }
    }
}