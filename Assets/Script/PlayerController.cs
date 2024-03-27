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
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    private bool isDead;

    private bool jumpKeyPress;

    private bool playerIsOnGround;

    public static PlayerController instance;
    [SerializeField]
    Animator animator;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        NmbrHp.instance.textUpdate();
    }


    // Update is called once per frame
    void Update()
    {
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir.Normalize();           //Normalize = reset la base � 1 (le total de X Y Z = 1)
        //if (Input.GetAxis("Jump") > 0)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPress = true;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HpUpdate();

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Game Over");
            //GameManager.instance.GameOver();
            Destroy(this.gameObject);
        }
    }
    private void HpUpdate()
    {
        healthBar.SetHealth(currentHealth);
        NmbrHp.instance.textUpdate();
    }


    private void FixedUpdate()
    {
        Move();
        UpdateAnimation(inputDir);
        if (jumpKeyPress)
        {
            Jump();
        }
    }

    void Move()
    {
        Vector3 forwardDir = transform.forward * inputDir.z; //inputDir.z = avance � l'intenssiter (surtout utiliser sur manette)
        forwardDir.Normalize();
        forwardDir *= moveSpeed;        //noramlize (1) *= movespeed(10) = 1 * 10 = 10

        Vector3 strafDir = Vector3.Cross(Vector3.up, transform.forward) * inputDir.x;
        strafDir.Normalize();
        strafDir *= moveSpeed;

        Vector3 finalDir = forwardDir + strafDir;
        rb.MovePosition(transform.position + (finalDir * Time.deltaTime));

        float targetRotation = cam.transform.eulerAngles.y;

        float playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref CurrentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, playerAngleDamp, 0);
    }
    void Jump()
    {
        rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        jumpKeyPress = false;
    }
    private void UpdateAnimation(Vector3 dir)
    {
        animator.SetFloat("Forward", dir.z);
        animator.SetFloat("Straf", dir.x);
    }

}
