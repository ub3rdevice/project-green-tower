using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 20;
    public bool CreateTower(Tower tower, Vector3 position)
    {
        ResourceStock resourceStock = FindObjectOfType<ResourceStock>();

        if(resourceStock == null)
        {
            return false;
        }

        if(resourceStock.CurrentResourceAmount >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            resourceStock.ReduceResources(cost);
            return true;
        }
        return false;
    }
}
