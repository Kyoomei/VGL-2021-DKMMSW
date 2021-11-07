using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Boundary boundary;
    Transform transform;
    float speed = 4.0f;
    float time;
    public GameObject laser;
    public float cooldown;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        // Player inputs
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);

        // Gestion du temps
        if (time > 0f)
        {
            time -= Time.fixedDeltaTime;
        }

        // Fire lasers
        if (Input.GetAxis("Fire1") != 0 && time <= 0)
        {
            Instantiate(laser, transform.TransformPoint(Vector3.forward * 2), transform.localRotation);
            time = cooldown;
        }
        
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.name == "Alien3"){
                EndPlayer();
                
            }
    }

    void EndPlayer(){
        GetComponent<Collider>().enabled = false;
        rb.velocity = Vector3.zero;
        Destroy(this.gameObject, 1);
    }
}
