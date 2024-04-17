using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    WaypointsPathController waypointsPathController;
    [SerializeField]
    float speed = 5;

    // Start is called before the first frame update
    private void Start()
    {
        EnnemiAi();
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
            bool pathEndReached = waypointsPathController.PathEndReached(currentWaypointIndex);
            waypointInfo = waypointsPathController.GetNextWaypoint(currentWaypointIndex);
            currentWaypointIndex = waypointInfo.index;
            if (pathEndReached)
            {
                transform.position = waypointInfo.target.position;
            }
            else
            {
                Vector3 startPos = transform.position;
                Vector3 targetPos = waypointInfo.target.position;
                float t = 0;
                while (t < 1.01f)
                {
                    //Debug.Log(Vector3.Distance(transform.position, waypointInfo.target.position));
                    transform.position = Vector3.Lerp(startPos, targetPos, t);
                    t += Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}
