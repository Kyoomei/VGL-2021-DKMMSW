using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKTonneau : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;

    

    public void GoToLeft()
    {
        rb.velocity = Vector3.left * speed;
    }
}
