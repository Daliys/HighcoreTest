using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent _navMesh;
    private Vector3 _moveTo;
    private float waypointReachedThreshold = 2f;

    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _moveTo = GetRandomPositionToMove();
    }

    public void MovementUpdate()
    {
        if(Vector3.Distance(transform.position, _moveTo) < waypointReachedThreshold)
        {
            _moveTo = GetRandomPositionToMove();
        }
        _navMesh.SetDestination(_moveTo);
        Debug.DrawLine(transform.position, _moveTo, Color.blue);
    }
    

    public Vector3 GetRandomPositionToMove()
    {
        Vector3 finishRandomPosition = Vector3.zero;

        Vector2 enemyPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 randomPoint = enemyPos + Random.insideUnitCircle * 12;
        finishRandomPosition = new Vector3(randomPoint.x, transform.position.y, randomPoint.y);

        if (IsItPossibleToReach(finishRandomPosition)) return finishRandomPosition;
        return GetRandomPositionToMove();
    }

    private bool IsItPossibleToReach(Vector3 position)
    {
        NavMeshPath path = new NavMeshPath();       
        _navMesh.CalculatePath(position, path);
        return (path.status == NavMeshPathStatus.PathComplete);
    }

}
