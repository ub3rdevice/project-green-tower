using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceStock : MonoBehaviour
{
    [SerializeField] int startingResourceAmount = 150;
    [SerializeField] int currentResourceAmount;
    Score score;
    public int CurrentResourceAmount {get { return currentResourceAmount; } }

    void Awake()
    {
        currentResourceAmount = startingResourceAmount;
    }

    void Start()
    {
        InitializeScoreObject();
        score.UpdateDisplay();
    }

    void InitializeScoreObject()
    {
        score = FindObjectOfType<Score>();
    }

    public void AddResources(int amount)
    {
        currentResourceAmount += Mathf.Abs(amount); //protection agains negative values;
        score.UpdateDisplay();
    }

    public void ReduceResources(int amount)
    {
        currentResourceAmount -= Math.Abs(amount);
        score.UpdateDisplay();

        if (currentResourceAmount < 0)
        {
            //game over
            ReloadLevel();
        }
    }

    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
