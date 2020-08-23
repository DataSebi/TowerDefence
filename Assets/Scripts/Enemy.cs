using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int currentTargetWaypointIndex;
    public float movementSpeed = 5.0f;
    private GameManager gameMananger;
    // Start is called before the first frame update
    void Start()
    {
        currentTargetWaypointIndex = 0;
        gameMananger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float movementStep = movementSpeed * Time.deltaTime;
        GameObject currentTargetWaypoint = gameMananger.waypoints[currentTargetWaypointIndex];

        float distance = Vector3.Distance(transform.position, currentTargetWaypoint.transform.position);
        if (distance <= 0)
        {
            if (currentTargetWaypoint.CompareTag("FinalWaypoint"))
            {
                gameMananger.LoseHealth();
                Destroy(gameObject);
                return;
            } else
            {
                currentTargetWaypointIndex += 1;
                currentTargetWaypoint = gameMananger.waypoints[currentTargetWaypointIndex];
            }
        }
        //move enemy
        transform.position = Vector3.MoveTowards(transform.position, currentTargetWaypoint.transform.position, movementStep);

    }
    
}
