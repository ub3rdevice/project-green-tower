using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize; //vector2int = grid ref with x axis and y axis

    [Tooltip("GlobalGridSize = UnityEditor snap settings")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize {get {return unityGridSize; } }

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    

    void Awake()
    {
        PopulateGrid();
    }

    public Node GetNode(Vector2Int coords)
    {
        if(grid.ContainsKey(coords))
        {
            return grid[coords];
        }

        return null;
    }

    public void BlockNode(Vector2Int coords)
    {
        if(grid.ContainsKey(coords))
        {
            grid[coords].isNavigable = false;
        }
    }

    public void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }

    public Vector2Int GetCoordsFromPosition(Vector3 position)
    {
        Vector2Int coords = new Vector2Int();

        coords.x = Mathf.RoundToInt((position.x) / unityGridSize); 
        coords.y = Mathf.RoundToInt((position.z) / unityGridSize);

        return coords;
    }

    public Vector3 GetPosFromCoords(Vector2Int coords)
    {
        Vector3 pos = new Vector3();

        pos.x = coords.x * unityGridSize;
        pos.z = coords.y * unityGridSize;

        return pos;
    }
    

    void PopulateGrid()
    {
        for(int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coords = new Vector2Int(x,y);
                grid.Add(coords, new Node(coords, true));
                
            }
        }
    }
}
