using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float difficulty;

    public Rigidbody rb;

    public float speed;

    public Transform target;

[SerializeField]
    int life;

    AudioSource destroySound;

    public int Life{
        get{
            return life;
        }
        set{
            life--;
            if (life == 0)
            {
                if (gameObject.tag == "AsteroidL")
                {
                    EndAsteroid();

                }
                else if (gameObject.tag == "AsteroidB")
                {
                    SplitAsteroid();

                }
            }
        }
    }

    public Sprite endSprite;

    public SpriteRenderer actualSprite;

    public GameObject asteroidL;

    public AsteroidManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        destroySound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("perdu");
        }
    }

    private void Update()
    {
        Invoke("SetTrajectory", 0.5f);
        
    }

    public void SetTrajectory()
    {
        manager = GameObject.FindWithTag("gm").GetComponent<AsteroidManager>();
        rb.velocity = (target.transform.position - transform.position).normalized * speed;
    }

    public void EndAsteroid()
    {
        GetComponent<Collider>().enabled = false;
        actualSprite.sprite = endSprite;
        rb.velocity = Vector3.zero;
        manager.asteroidNumber--;
        manager.Score++;
        destroySound.Play();
        Destroy(this.gameObject, 1);
    }

    void SplitAsteroid()
    {
       GameObject ast = Instantiate(asteroidL, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1), Quaternion.Euler(90, 0, 0));
        ast.GetComponent<Asteroid>().SetTrajectory();
       GameObject ast2 = Instantiate(asteroidL, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1), Quaternion.Euler(90, 0, 0));
        ast2.GetComponent<Asteroid>().SetTrajectory();
        manager.asteroidNumber++;
        destroySound.Play();
        Destroy(this.gameObject);
    }
    
}
