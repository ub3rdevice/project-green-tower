using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isValidForPlacement;
    public bool IsValidForPlacement { get { return isValidForPlacement; } } // fancy getter or getproperty to be precise

    // public bool GetIsValidForPlacement() // good old getter
    // {
    //     return isValidForPlacement;
    // }

   void OnMouseDown() 
   {
        if(isValidForPlacement)
        {
            Instantiate(towerPrefab,transform.position,Quaternion.identity);
            isValidForPlacement = false;
        }
        
   }
}
