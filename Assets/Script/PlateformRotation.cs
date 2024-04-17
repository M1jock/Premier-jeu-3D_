using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 3; //3 is the base speed, unity override it if changed in unity
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

    }
}

