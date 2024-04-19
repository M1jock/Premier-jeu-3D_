using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coin;
    [SerializeField]
    List<Transform> spawnPoint;
    private void Awake()
    {
        spawnPoint = new List<Transform>();
        foreach (Transform t in transform)
        {
            spawnPoint.Add(t);
        }
    }
    private void Start()
    {
        foreach (Transform t in spawnPoint)
        {
            int randomIndex = Random.Range(0, coin.Length);
            int currenIndex = spawnPoint.IndexOf(t);

            Instantiate(coin[randomIndex], t.position , Quaternion.identity);

        }
    }
}
