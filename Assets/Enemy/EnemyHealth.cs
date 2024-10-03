using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHP = 5;

    [Tooltip("Additional amount to maxHP to the same enemy after each respawn")]
    [SerializeField] int difficultyFactor = 1;
    int currentHP = 0;
    Enemy enemy;

    void OnEnable()
    {
        setCurrentHP();
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        
    }

    void setCurrentHP()
    {
        currentHP = maxHP;
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit(); 

        if (currentHP <= 0)
        {
            DestoyEnemy();
        }
    }
    void ProcessHit() //add VFX and SFX
    {
        currentHP--;
    }

    void DestoyEnemy()
    {
        gameObject.SetActive(false); //adding object back to object pool instead of destroying it completely
        maxHP += difficultyFactor; //makes new iteration of the same enemy stronger with each respawn
        enemy.RewardPlayer();
    }
}
