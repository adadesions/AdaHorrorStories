using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] float speed = 4.0f;
    [SerializeField] float jumpPower = 4.0f;
    [SerializeField] float jumpRateTime = 0.5f;
    [SerializeField] Weapon1 weapon;
    private Rigidbody rb;
    private Animator animator;
    private float lastTimeJump = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
        Jump();
        weapon.Fire();
    }

    private void Jump()
    {        
        bool isAllowJump = Time.time > lastTimeJump + jumpRateTime;
        if (Input.GetButtonDown("Jump") && isAllowJump)
        {
            RaycastHit hits;
            bool isHit = Physics.Raycast(transform.position, Vector3.down, out hits, 1.0f);
            Debug.DrawLine(transform.position, transform.position + Vector3.down, Color.red);
            print(isHit);
            print(hits.collider);

            lastTimeJump = Time.time;
            animator.SetTrigger("IsJump");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void Movements()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis != 0 || vAxis != 0)
        {
            Vector3 moveVector = new Vector3(hAxis, 0, vAxis);
            transform.position += moveVector * speed * Time.deltaTime;            

            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
}
