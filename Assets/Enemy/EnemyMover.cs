using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f,10f)] float mainSpeed = 1f;
    List<Node> path = new List<Node>();
    Enemy enemy;
    Pathfinder pathfinder;
    GridManager gridManager;

    void OnEnable()
    {   
        returnToStartPos();
        RecalcPath(true);
    }

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
        enemy = GetComponent<Enemy>();
    }
    
    void RecalcPath(bool resetPath)
    {
        Vector2Int coords = new Vector2Int();

        if(resetPath)
        {
            coords = pathfinder.StartCoords;
        }
        else
        {
            coords = gridManager.GetCoordsFromPosition(transform.position);
        }

        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coords);
        StartCoroutine(StartMovement());
    }

    void returnToStartPos()
    {
        transform.position = gridManager.GetPosFromCoords(pathfinder.StartCoords);
    }

    void FinishMovement()
    {
        enemy.PenaltyPlayer();
        gameObject.SetActive(false); //adding object back to object pool instead of destroying it completely
    }

    IEnumerator StartMovement()
    {
        for (int i = 1; i < path.Count; i++)
        {   
            Vector3 startPos = transform.position;
            Vector3 endPos = gridManager.GetPosFromCoords(path[i].coords);
            float travelPart = 0f;

            transform.LookAt(endPos);

            while(travelPart < 1f)
            {
                travelPart += Time.deltaTime * mainSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPart);
                yield return new WaitForEndOfFrame();
            }
            
        }
        FinishMovement();
    }
}
