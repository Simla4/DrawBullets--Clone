using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent nMesh;
    private Queue<Vector3> pathPoints = new Queue<Vector3>();
    
    private void Awake()
    {
        FindObjectOfType<BulletPathCreator>().OnNewPathCreated += SetPoints;
    }

    void Update()
    {
        UpdatePathing();
    }

    private void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }

    private void UpdatePathing()
    {
        if(ShouldSetDestination())
            nMesh.SetDestination(pathPoints.Dequeue());
    }

    private bool ShouldSetDestination()
    {
        if(pathPoints.Count == 0)
            return false;
        if(nMesh.hasPath == false || nMesh.remainingDistance < 0.5f)
            return true;

        return false;
    }
}
