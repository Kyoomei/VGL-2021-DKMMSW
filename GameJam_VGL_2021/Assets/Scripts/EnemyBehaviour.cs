using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    float Speed;
    GameObject bg;
    GameObject wall;
    [SerializeField]
    Collider wallc;
    Transform transform;
    Vector3 originalPos;

    [SerializeField]
    public Boundary boundary;

    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        originalPos = transform.position;
        bg = GameObject.FindGameObjectsWithTag("Background")[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
    }
    private void OnCollisionEnter(Collision other)
    {
            if(other.gameObject.name == "Cube (1)" || other.gameObject.name == "Cube"){
                ChangeAlienDirection(originalPos);
            }
            if(other.gameObject.name == "Player" || other.gameObject.name == "Laser(Clone)"){
                EndEnemy();
            }
    }

    // change enemy direction on z axis
    void ChangeAlienDirection(Vector3 oPos){
        Speed = -Speed;
        Vector3 diff = new Vector3(0,0,2);
        this.gameObject.transform.position = this.gameObject.transform.position - diff;
    }

    void EndEnemy(){
        GetComponent<Collider>().enabled = false;
        // rb.velocity = Vector3.zero;
        Destroy(this.gameObject, 1);
    }

}
