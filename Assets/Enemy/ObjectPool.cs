using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 7;
    [SerializeField] [Range(0.1f, 25f)] float spawnDelayTimer = 1f;
    GameObject[] pool;

    void Awake()
    {
        AddToPool();
    }

    void AddToPool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++) //basic for loop, set i as 0 (because first element of array is 0) and add +1 to i until i = array length;
        {
            pool[i] = Instantiate(enemyPrefab,transform); //Instantiate an object for each element of the main array of objects;
            pool[i].SetActive(false); //turning off each array element as default state;
        }

        
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
   
    IEnumerator SpawnEnemy()
    {
        while(true) //bad practice, possible OOM
        {
            EnableOnjectFromPool();
            yield return new WaitForSeconds(spawnDelayTimer);
        }
        
    }

    void EnableOnjectFromPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
