using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;

    [SerializeField]
    public float moveSpeed = 10;

    [SerializeField]
    public float strafSpeed = 5;

    [SerializeField]
    Camera cam;

    Vector3 inputDir;

    float CurrentVelocity;
    float smoothTime = 0.05f;
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    private bool isDead;

    //private bool jumpKeyPress;

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
        isDead = false;
    }


    // Update is called once per frame
    void Update()
    {
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir.Normalize();           //Normalize = reset la base � 1 (le total de X Y Z = 1)
        //if (Input.GetAxis("Jump") > 0)
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded())
        {
            //jumpKeyPress = true;
            Jump();
            
        }
        UpdateAnimationPlayer(inputDir);
    }
    private void HpUpdate()
    {
        healthBar.SetHealth(currentHealth);
        NmbrHp.instance.textUpdate();
    }

    private void FixedUpdate()
    {
        Move();
        /*if (jumpKeyPress)
        {
            Jump();
        }*/
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
        //jumpKeyPress = false;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HpUpdate();
        
        if (currentHealth <= 0 && !isDead)
        {
            currentHealth = 0;
            Debug.Log("Game Over");
            isDead = true;
            UpdateAnimationPlayer(inputDir);
            //GameManager.instance.GameOver();
            Destroy(this.gameObject);
        }
    }
    public void UpdateAnimationPlayer(Vector3 dir)
    {
        if (isDead)
        {
            animator.SetBool("isDead", true);
        }
        animator.SetFloat("Forward", dir.z);
        animator.SetFloat("Straf", dir.x);
        if (!isGrounded())
        {
            
        }
        animator.SetBool("JumpUp", !isGrounded());
    }
    bool isGrounded()
    {
        return Mathf.Abs(rb.velocity.y) < 0.01f;
        //Si au dessus de la valeur f alors considéré en Jump
        //return Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, 0.2f);
        //Pareil que Mathf mais en raycast
    }
}
