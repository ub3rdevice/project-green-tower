using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoords;
    public Vector2Int StartCoords { get { return startCoords; } }
    [SerializeField] Vector2Int endCoords;
    public Vector2Int EndCoords { get { return endCoords; } }

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
            startNode = grid[startCoords];
            endNode = grid[endCoords];
        }
    }

    void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
       return GetNewPath(startCoords);
    }

     public List<Node> GetNewPath(Vector2Int coords)
    {
        gridManager.ResetNodes();
        BreadthFirstSearch(coords);
        return CreatePath();
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
                neighbor.connectedTo = currentSearchNode;
                reachedNodes.Add(neighbor.coords, neighbor);
                worldNodes.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSearch(Vector2Int coords)
    {
        startNode.isNavigable = true;
        endNode.isNavigable = true;

        worldNodes.Clear();
        reachedNodes.Clear();

        bool isRunning = true;

        worldNodes.Enqueue(grid[coords]);
        reachedNodes.Add(coords, grid[coords]);

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
    List<Node> CreatePath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while(currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();

        return path;
    }

    public bool willBlock(Vector2Int coords)
    {
        if(grid.ContainsKey(coords))
        {
            bool previousState =  grid[coords].isNavigable = true;
            grid[coords].isNavigable = false;
            List<Node> newPath = GetNewPath();
            grid[coords].isNavigable = previousState;

            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }
        return false;
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("RecalcPath",false, SendMessageOptions.DontRequireReceiver);
    }

}
