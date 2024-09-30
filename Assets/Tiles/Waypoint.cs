using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isValidForPlacement;
   void OnMouseDown() 
   {
        if(isValidForPlacement)
        {
            Debug.Log(transform.name);
        }
        
   }
}
