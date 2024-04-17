using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    Queue<Vector3> targetPos;
    [SerializeField]
    Transform target;
    [SerializeField]

    


    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Queue<Vector3>();
        StartCoroutine(ShadowBehaviourCorout());
    }
    IEnumerator ShadowBehaviourCorout()
    {
        float t=0;
        while (t<2) 
        {
            targetPos.Enqueue(target.position);
            t += Time.deltaTime;
            yield return null;

        }
        while (true)
        {
            targetPos.Enqueue(target.position);
            transform.position = targetPos.Dequeue(); //Dequeue = debut (le premier)

            yield return null;

        }

    }
}
