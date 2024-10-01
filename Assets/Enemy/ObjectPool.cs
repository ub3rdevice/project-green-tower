using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelayTimer = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
   
    IEnumerator SpawnEnemy()
    {
        while(true) //bad practice, possible OOM
        {
            Instantiate(enemyPrefab,transform);
            yield return new WaitForSeconds(spawnDelayTimer);
        }
        
    }
    
}
