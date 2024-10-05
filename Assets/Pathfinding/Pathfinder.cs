using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoords;
    [SerializeField] Vector2Int endCoords;

    Node startNode;
    Node endNode;
    Node currentSearchNode;

    Queue<Node> worldNodes = new Queue<Node>();
    Dictionary<Vector2Int, Node> reachedNodes = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }

        startNode = new Node(startCoords, true);
        endNode = new Node(endCoords, true);
    }

    void Start()
    {
        BreadthFirstSearch();
    }

    void CheckNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coords + direction;

            if (grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);
            }

        }
        foreach(Node neighbor in neighbors)
        {
            if(!reachedNodes.ContainsKey(neighbor.coords) && neighbor.isNavigable)
            {
                reachedNodes.Add(neighbor.coords, neighbor);
                worldNodes.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSearch()
    {
        bool isRunning = true;

        worldNodes.Enqueue(startNode);
        reachedNodes.Add(startCoords, startNode);

        while(worldNodes.Count >0 && isRunning)
        {
            currentSearchNode = worldNodes.Dequeue();
            currentSearchNode.isExplored = true;
            CheckNeighbors();
            if(currentSearchNode.coords == endCoords)
            {
                isRunning = false;
            }
        }
    }
}
