using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsPathController : MonoBehaviour
{
    [SerializeField]
    List<Transform> waypoints;
    [SerializeField]
    List<GameObject> plateformList;

    public GameObject myPlatformPrefab;
    public Transform spawnPoint;


    private void Awake()
    {
        waypoints = new List<Transform>();
        foreach (Transform t in transform)
        {
            waypoints.Add(t);
        }
    }
    // This script will simply instantiate the Prefab when the game starts.
    void Spawn()
    {
        if (plateformList.Count < waypoints.Count)
        {
            // Instantiate at position spawnPoint and zero rotation.
            Instantiate(myPlatformPrefab, spawnPoint.position, Quaternion.identity);

        }
    }
    public WaypointInfo GetNextWaypoint(int currentIndex)
    {
        WaypointInfo result = new WaypointInfo();
        if (currentIndex == waypoints.Count - 1) // int start: 0 | List start: 1
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

    public bool PathEndReached(int currentIndex)
    {
        return currentIndex >= waypoints.Count - 1; //current index commence a 0 // waypoint count commence à 1
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
