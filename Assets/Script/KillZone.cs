using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    float startDelay = 5;
    [SerializeField]
    float speed = 1;
    private void Start()
    {
        StartCoroutine(Move());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        PlayerController.instance.TakeDamage(200);
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
            yield return null;
        }

    }
}
