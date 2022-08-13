using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpPower = 3.0f;
    [SerializeField] private float fireRate = 0.3f;
    [SerializeField] private float maxJumpDistance = 3.0f;
    private Animator animator;
    private Rigidbody rb;
    private Transform playerModel;
    private float lastTimeJump = 0.0f;
    private float lastTimeFire = 0.0f;
    private Weapon curWeapon;

    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel").transform;
        curWeapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FireActive();
    }

    private void FireActive()
    {
        bool isAllowFire = Time.time > lastTimeFire + fireRate;
       if (Input.GetButton("Fire1") && isAllowFire)
        {
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");
            if (hAxis != 0 || vAxis != 0)
            {
                animator.SetBool("IsFiring", true);
                animator.SetBool("IsStandFiring", false);
            }
            else
            {
                animator.SetBool("IsStandFiring", true);
            }

            curWeapon.Fire();
            
        }
       else
        {
            animator.SetBool("IsFiring", false);
            animator.SetBool("IsStandFiring", false);
        }
    }

    private void Movement()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis != 0 || vAxis != 0)
        {
            if (vAxis < 0)
            {
                playerModel.eulerAngles = new Vector3(0, 210, 0);               
            }
            else
            {
                playerModel.eulerAngles = new Vector3(0, 30, 0);                
            }

            animator.SetBool("IsRunning", true);
            Vector3 movingVector = new Vector3(hAxis, 0, vAxis);
            transform.position += movingVector * speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        bool isAllowJump = Time.time > lastTimeJump + 0.3f;
        if (Input.GetButton("Jump") && isAllowJump)
        {
            RaycastHit hits;
            bool isHits = Physics.Raycast(transform.position, Vector3.down,out hits, maxJumpDistance);
            if (isHits && hits.collider != null)
            {
                print("Hits");
                print(hits.collider.gameObject.tag);
                lastTimeJump = Time.time;
                animator.SetTrigger("IsJump");
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
            
        }
    }
}
