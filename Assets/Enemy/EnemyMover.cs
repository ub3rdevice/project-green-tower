using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,10f)] float mainSpeed = 1f;
    Enemy enemy;

    void OnEnable()
    {   
        LookForPath();
        returnToStartPos();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    
    void LookForPath()
    {
        path.Clear();

        GameObject pathParent = GameObject.FindGameObjectWithTag("Path"); //better to not use any string references in a future

        foreach(Transform child in pathParent.transform) //using Transform here due to empty gameobject has only Transform component
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void returnToStartPos()
    {
        transform.position = path[0].transform.position;
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
        enemy.PenaltyPlayer();
        gameObject.SetActive(false); //adding object back to object pool instead of destroying it completely
    }
}
