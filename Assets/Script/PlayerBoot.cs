using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoot : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            new WaitForSeconds(1);
            PersistantData.instance.ennemyKilled += 1;
            GameObject.Destroy(other.gameObject);
        }
    }
}
