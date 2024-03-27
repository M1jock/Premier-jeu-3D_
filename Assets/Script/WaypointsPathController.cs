using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsPathController : MonoBehaviour
{
    [SerializeField]
    List<Transform> waypoints;

    private void Awake()
    {
        waypoints = new List<Transform>();
        foreach (Transform t in transform)
        {
            waypoints.Add(t);
        }
    }
    public WaypointInfo GetNextWaypoint(int currentIndex)
    {
        WaypointInfo result = new WaypointInfo();
        if (currentIndex == waypoints.Count - 1)
        {
            result.index = 0;
        }
        else
        {
            result.index = currentIndex + 1;
        }
        Debug.Log(result.index);
        result.target = waypoints[result.index];
        return result;
    }
    public class WaypointInfo
    {
        public int index;
        public Transform target;
        public WaypointInfo(int Index, Transform target)
        {
            index = Index;
            this.target = target;
        }
        public WaypointInfo()
        {
            index = 0;
            target = null;
        }
    }

}
