using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public WayPoints7 wayPoints;
    private float movespeed = 5f;
    private float distances = 0.1f;
    private Transform currwaypoints;

    void Start()
    {
        currwaypoints = wayPoints.GetNextWayPoint(currwaypoints);
        transform.position = currwaypoints.position;

        currwaypoints = wayPoints.GetNextWayPoint(currwaypoints);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currwaypoints.position, movespeed * UnityEngine.Time.deltaTime);
        if(Vector3.Distance(transform.position, currwaypoints.position) < distances)
        {
            currwaypoints = wayPoints.GetNextWayPoint(currwaypoints);
        }
    }
}
