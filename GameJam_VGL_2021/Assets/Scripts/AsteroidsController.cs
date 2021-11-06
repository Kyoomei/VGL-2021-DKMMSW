using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class AsteroidsController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    Rigidbody rigidbody;

    public GameObject laser;
    public float time = 0f;
    public float cooldown = 1f;

    private Vector3 lookDirection = Vector3.zero;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        transform.eulerAngles = new Vector3(0, Mathf.Atan2(moveHorizontal, moveVertical) * 180 / Mathf.PI, 0);

        if (time > 0f)
        {
            time -= Time.fixedDeltaTime;
        }

        if (Input.GetAxis("Fire1") != 0 && time <= 0)
        {
            Instantiate(laser, transform.TransformPoint(Vector3.forward * 2), transform.localRotation);
            time = cooldown;
        }
        
    }
}
