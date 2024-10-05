using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 20;
    [SerializeField] float buildTime = 0.25f;

    void Start() {
        StartCoroutine(Build());
    }

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

    IEnumerator Build()
    {   
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        foreach(Transform child in transform)
        {
            yield return new WaitForSeconds(buildTime);
            child.gameObject.SetActive(true);

        }
    }
}
