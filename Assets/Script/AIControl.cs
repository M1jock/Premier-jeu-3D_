using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    Transform target;
    [SerializeField]
    WaypointsPathController waypointsPathController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
    public void EnnemiAi()
    {
        StartCoroutine(PatrolCorout());
    }
    IEnumerator PatrolCorout()
    {
        int currentWaypointIndex = 0;
        WaypointsPathController.WaypointInfo waypointInfo;
        while (true)
        {
            waypointInfo = waypointsPathController.GetNextWaypoint(currentWaypointIndex);
            agent.SetDestination(waypointInfo.target.position);
            while (agent.remainingDistance > 1.6f)
            {
                Debug.Log(agent.remainingDistance);
                yield return null;
            }
        }
    }

    void InArea()
    {
        float distance = Vector3.Distance(agent.transform.position, target.transform.position);
    }
}
