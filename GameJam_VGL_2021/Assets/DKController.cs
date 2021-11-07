using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKController : MonoBehaviour
{
    public Rigidbody rb;
    
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundMask;

    public RaycastHit hit;

    public bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, out hit, checkRadius, groundMask);
        

        
           

        if (Input.GetAxis("Fire1") != 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }

        
    }
}
