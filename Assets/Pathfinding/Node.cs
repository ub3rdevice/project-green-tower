using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int coords;
    public bool isNavigable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int coords, bool isNavigable)
    {
        this.coords = coords; //"this" helps to set coords from method args to coords in public var
        this.isNavigable = isNavigable;
    }
}
