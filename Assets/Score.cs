using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayResources;
    ResourceStock resourceStock;

    void initializeResourceStockObject()
    {
        resourceStock = FindObjectOfType<ResourceStock>();
    }

    public void UpdateDisplay()
    {
        initializeResourceStockObject();
        displayResources.text = "Resources: " + resourceStock.CurrentResourceAmount;
    }
}
