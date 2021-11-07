using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed;

    AudioSource ballHit;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    public void SpawnBall()
    {
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1, Random.Range(-0.2f, 0.2f)) * speed;
        ballHit = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        ballHit.Play();

        if (collision.gameObject.name == "Player")
        {
            float y = HitFactor(transform.position,
                collision.transform.position,
                collision.collider.bounds.size.y
                );

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }



        
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathZone")
        {
            Destroy(gameObject);
        }
    }
}
