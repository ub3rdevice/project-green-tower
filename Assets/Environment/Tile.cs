using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isValidForPlacement;
    public bool IsValidForPlacement { get { return isValidForPlacement; } } // fancy getter or getproperty to be precise

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coords = new Vector2Int();

    // public bool GetIsValidForPlacement() // good old getter
    // {
    //     return isValidForPlacement;
    // }

    void Awake()
    {
        pathfinder = FindObjectOfType<Pathfinder>();
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start() 
    {
        if(gridManager != null)
        {
            coords = gridManager.GetCoordsFromPosition(transform.position);

            if(!isValidForPlacement)
            {
                gridManager.BlockNode(coords);
            }
        }
    }

   void OnMouseDown() 
   {
        if(gridManager.GetNode(coords).isNavigable && !pathfinder.willBlock(coords))
        {
            bool isSuccessfulPlacement = towerPrefab.CreateTower(towerPrefab, transform.position);
            
            if (isSuccessfulPlacement)
            {
                gridManager.BlockNode(coords);
                pathfinder.NotifyReceivers();
            }
        }
   }
}
