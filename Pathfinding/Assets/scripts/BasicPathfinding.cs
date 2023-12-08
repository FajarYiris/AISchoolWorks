using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class BasicPathfinding : MonoBehaviour
{
    public Transform[] Points; //untuk poin yang akan dilewati npc
    private NavMeshAgent nav; //untuk import navmesh pada npc
    private int destpoint; //untuk mengetahui jumlah poin yang harus dilewati

    void Start()
    {
        nav = GetComponent<NavMeshAgent>(); //import navmesh
    }

    void Update()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if(Points.Length == 0)
        {
            return;
        }
        nav.destination = Points[destpoint].position;
        destpoint = (destpoint + 1) % Points.Length;
    }
}
