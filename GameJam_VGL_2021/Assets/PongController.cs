using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveVertical) * speed; ;
    }
}
