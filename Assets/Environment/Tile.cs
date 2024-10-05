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
    Vector2Int coords = new Vector2Int();

    // public bool GetIsValidForPlacement() // good old getter
    // {
    //     return isValidForPlacement;
    // }

    void Awake()
    {
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
        if(isValidForPlacement)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isValidForPlacement = !isPlaced;
        }
        
   }
}
