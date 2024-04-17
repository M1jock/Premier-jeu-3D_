using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField]
    List<GameObject> plateformList;

    public GameObject myPlatformPrefab;
    public Transform spawnPoint;


    private void Awake()
    {
        //waypoints = GetComponent<Patrol>(List waypointsPathController);
    }
    void Spawn()
    {
        //if (plateformList.Count < waypoints.Count)
        {
            // Instantiate at position spawnPoint and zero rotation.
            Instantiate(myPlatformPrefab, spawnPoint.position, Quaternion.identity);

        }
    }
}
