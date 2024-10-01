using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLookAt : MonoBehaviour
{
    Transform target;

    void Start()
    {
        FindAnEnemy();
    }

   

    void Update()
    {
        TakeAim();
    }

    void TakeAim()
    {
        transform.LookAt(target);
    }

    void FindAnEnemy()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }
}
