using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAsteroid : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        Destroy(this, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AsteroidL" || other.tag == "AsteroidB")
        {
            other.GetComponent<Asteroid>().life--;
            Destroy(this.gameObject);
        }
    }
}
