using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float waypointsize = 1f;

    [Header("Path Setting")]
    [SerializeField] private bool canloop = true;
    [SerializeField] private bool Forward = true;
    private void OnDrawGizmos() {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, 1f);
        }

        Gizmos.color = Color.red;
        for(int i = 0; i < transform.childCount - 1; i++)
        {
          Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }

        if(canloop)
        {
            Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        }

        
    }

    public Transform GetNextWayPoint(Transform currentWaypoint)
    {
        if(currentWaypoint == null)
        {
            return transform.GetChild(0);
        }

        int currentindex = currentWaypoint.GetSiblingIndex();
        int nextindex = currentindex;

        if(Forward)
        {
            nextindex+=1;

            if(nextindex == transform.childCount - 1 && canloop)
            {
                nextindex = 0;
            }
            nextindex -= 1;
        }

        else
        {
            nextindex -= 1;

            if (nextindex < 0)
            {
                if (canloop)
                {
                    nextindex = transform.childCount - 1;
                }
                nextindex += 1;
                
            }
        }

        if(currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {
            if(canloop)
            {
                return transform.GetChild(0);
            }
            return transform.GetChild(currentWaypoint.GetSiblingIndex());
        }
        // return transform.GetChild(nextindex);
    }
}
