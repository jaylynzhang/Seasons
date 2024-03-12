using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// YouTube tutorial: https://www.youtube.com/watch?v=f473C43s8nE

public class PlayerMovements : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    RaycastHit hit;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Reset();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (rb.position.y < -10f)
        {
            Reset();
        }

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f);


        MyInput();

        rb.drag = groundDrag;
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        float slopeMultiplier = 1f;
        if (Physics.Raycast(transform.position, transform.forward, out hit, moveSpeed))
        {
            float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
            if (slopeAngle > 30)
            {
                slopeMultiplier = 2f; // Adjust the slopeMultiplier as needed
            }
        }

        rb.AddForce(moveDirection.normalized * moveSpeed * slopeMultiplier, ForceMode.Force);


        //if (grounded)
        //{
        //    rb.drag = groundDrag;
        //} else
        //{
        //    rb.drag = 0;
        //}
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Reset()
    {
        rb.position = new Vector3(-36.3f, 0, -34.6f);
    }


    // Update is called once per frame
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * (0.1f * moveSpeed);
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
