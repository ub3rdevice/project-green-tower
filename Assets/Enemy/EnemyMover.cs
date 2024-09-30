using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,10f)] float mainSpeed = 1f;

    void Start()
    {
        StartCoroutine(FollowPath());
    }
    
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {   
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPart = 0f;

            transform.LookAt(endPos);

            while(travelPart < 1f)
            {
                travelPart += Time.deltaTime * mainSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPart);
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}
