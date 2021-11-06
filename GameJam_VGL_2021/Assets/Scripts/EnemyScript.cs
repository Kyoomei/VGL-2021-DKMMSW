using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float speed;
    private Transform enemyHolder;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            
            speed = value;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        Speed = GameManager.instance.loop * 2f;
        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
        enemyHolder = GetComponent<Transform>();
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
    }

    // Update is called once per frame
    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x >= 8)
            {
                enemy.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
                speed = -speed;
                enemyHolder.position += Vector3.down * .5f;
                GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
                return;
            }
            else if (enemy.position.x <= -8)
            {
                enemy.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
                speed = -speed;
                enemyHolder.position += Vector3.down * .5f;
                GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
                return;
            }
            

            if (enemy.position.y <= -3)
            {
                Debug.Log("perdu");
                Time.timeScale = 0;
            }
        }

       /* if (enemyHolder.childCount == 1)
        {
            speed = speed * 2;
        }*/

        if (enemyHolder.childCount == 0)
        {
            Debug.Log("gg");
        }
    }
}
