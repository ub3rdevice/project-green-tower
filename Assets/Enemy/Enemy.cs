using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int resourceReward = 15;
    [SerializeField] int resourcePenalty = 20;

    ResourceStock resourceStock;

    void Start()
    {
        resourceStock = FindObjectOfType<ResourceStock>();
    }

    public void RewardPlayer()
    {
        if(resourceStock == null) { return; }
        resourceStock.AddResources(resourceReward);
    }

    public void PenaltyPlayer()
    {
        if(resourceStock == null) { return; }
        resourceStock.ReduceResources(resourcePenalty);
    }
}
