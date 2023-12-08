using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private waypoints waypoints;
    [SerializeField] private float movespeed = 5f;

    [Range(0f,15f)]
    [SerializeField] private float rotatespeed = 1f;
    [SerializeField] private float distances = 0.1f;

    private Transform currentWaypoint;

    private Quaternion rotationgoal;
    private Vector3 directionalToWayPoints;

     void Start() 
    {
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, movespeed * UnityEngine.Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distances)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        }
        RotateTowardWaypoints();
    }

    private void RotateTowardWaypoints()
    {
        directionalToWayPoints = (currentWaypoint.position - transform.position).normalized;
        rotationgoal = Quaternion.LookRotation(directionalToWayPoints);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationgoal, rotatespeed * UnityEngine.Time.deltaTime);
    }
}
