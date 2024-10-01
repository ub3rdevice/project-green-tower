using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isValidForPlacement;
   void OnMouseDown() 
   {
        if(isValidForPlacement)
        {
            Instantiate(towerPrefab,transform.position,Quaternion.identity);
            isValidForPlacement = false;
        }
        
   }
}
