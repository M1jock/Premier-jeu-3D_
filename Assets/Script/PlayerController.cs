using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;

    Vector3 inputDir;

    [SerializeField]
    public float moveSpeed = 10;

    [SerializeField]
    public float strafSpeed = 5;

    [SerializeField]
    Camera cam;

    float CurrentVelocity;
    float smoothTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir.Normalize();           //Normalize = reset la base � 1 (le total de X Y Z = 1)
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 forwardDir = transform.forward * inputDir.z; //inputDir.z = avance � l'intenssiter (surtout utiliser sur manette)
        forwardDir.Normalize();
        forwardDir *= moveSpeed;        //noramlize (1) *= movespeed(10) = 1 * 10 = 10

        Vector3 strafDir = Vector3.Cross(Vector3.up,transform.forward) * inputDir.x;
        strafDir.Normalize();
        strafDir *= moveSpeed;

        Vector3 finalDir = forwardDir + strafDir;
        rb.MovePosition(transform.position + (finalDir * Time.deltaTime));

        float targetRotation = cam.transform.eulerAngles.y;

        float playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref CurrentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0,playerAngleDamp,0);
    }

}
