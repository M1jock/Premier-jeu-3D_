using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiDmgZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.instance.TakeDamage(10);
            new WaitForSeconds(3);
            return;
        }
    }
}
