using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHP = 5;
    [SerializeField] int currentHP = 0;

    void OnEnable()
    {
        setCurrentHP();
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

        if (currentHP <1)
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
    }
}
