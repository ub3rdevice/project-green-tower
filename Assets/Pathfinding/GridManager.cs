using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize; //vector2int = grid ref with x axis and y axis
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    void Awake()
    {
        PopulateGrid();
    }

    void PopulateGrid()
    {
        for(int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coords = new Vector2Int(x,y);
                grid.Add(coords, new Node(coords, true));
                Debug.Log(grid[coords].coords + " = " + grid[coords].isNavigable);
            }
        }
    }
}
