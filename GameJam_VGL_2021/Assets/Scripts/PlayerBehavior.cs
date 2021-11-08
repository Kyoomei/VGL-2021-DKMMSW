using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Boundary boundary;
    Transform transform;
    float speed = 4.0f;
    float velocity = 1.5f;
    float time;
    public GameObject laser;
    public float cooldown;
    public Rigidbody rb;
    public Transform spawnLaser;
    Animator animator;
    public ParticleSystem fireShoot;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();
        //fireShoot = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Player inputs
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed * velocity);

        // Gestion du temps
        if (time > 0f)
        {
            time -= Time.fixedDeltaTime;
        }

        // Fire lasers
        if (Input.GetAxis("Fire1") != 0 && time <= 0)
        {
            Instantiate(laser, spawnLaser.position, transform.localRotation);
            time = cooldown;
            animator.SetTrigger("shoot");
            fireShoot.Play();
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
        Destroy(gameObject);
    }
}
