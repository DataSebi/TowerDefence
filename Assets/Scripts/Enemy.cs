using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<GameObject> waypoints;
    public int currentTargetWaypointIndex;
    public float movementSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentTargetWaypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        float movementStep = movementSpeed * Time.deltaTime;
        GameObject currentTargetWaypoint = waypoints[currentTargetWaypointIndex];

        float distance = Vector3.Distance(transform.position, currentTargetWaypoint.transform.position);
        if (distance <= 0)
        {
            currentTargetWaypointIndex += 1;
            currentTargetWaypoint = waypoints[currentTargetWaypointIndex];
        }
        //move enemy
        transform.position = Vector3.MoveTowards(transform.position, currentTargetWaypoint.transform.position, movementStep);
        if (currentTargetWaypoint.CompareTag("FinalWaypoint"))
        {
            Debug.Log("Remove One Health");
            Destroy(gameObject);
        }
    }

    
}
