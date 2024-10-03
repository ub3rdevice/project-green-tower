using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceStock : MonoBehaviour
{
    [SerializeField] int startingResourceAmount = 150;
    [SerializeField] int currentResourceAmount;
    public int CurrentResourceAmount {get { return currentResourceAmount; } }

    void Awake() {
        currentResourceAmount = startingResourceAmount;
    }

    public void AddResources(int amount)
    {
        currentResourceAmount += Mathf.Abs(amount); //protection agains negative values;
    }

    public void ReduceResources(int amount)
    {
        currentResourceAmount -= Math.Abs(amount);

        if (currentResourceAmount < 0)
        {
            ReloadLevel();
        }
    }

    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
