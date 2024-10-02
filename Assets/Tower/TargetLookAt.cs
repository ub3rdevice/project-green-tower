using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLookAt : MonoBehaviour
{
    Transform target;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticles;

    void Update()
    {
        FindClosestTarget();
        TakeAim();
    }

    void TakeAim()
    {
        transform.LookAt(target);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (range > distanceToTarget)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
        
    }

    void Attack(bool isActive)
    {
        var emissionSetting = projectileParticles.emission;
        emissionSetting.enabled = isActive;
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies) //not the best way in case of lots of enemies
        {
            float distanceToTarget = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToTarget < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = distanceToTarget;
            }
        }
        target = closestTarget;
    }
}
