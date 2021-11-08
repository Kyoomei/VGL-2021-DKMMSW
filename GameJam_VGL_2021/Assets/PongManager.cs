using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    public GameObject ballPrefab;

    public float timer;

    public Transform spawn1, spawn2, spawn3;

    GameObject ball;
    GameObject ball2;
    GameObject ball3;

    public bool gameStart;
    public bool timerIsRunning = true;

    private void StartGame()
    {
        switch (GameManager.instance.loop)
        {
            case 1:
                ball = Instantiate(ballPrefab, new Vector3(3.65f, 0, 0), Quaternion.identity);
                ball.GetComponent<BallScript>().speed = 10f;
                ball.GetComponent<BallScript>().SpawnBall();
                break;

            case 2:
                ball = Instantiate(ballPrefab, new Vector3(3.8f, -0.5f, 0), Quaternion.identity);
                ball.GetComponent<BallScript>().speed = 10f;
                ball.GetComponent<BallScript>().SpawnBall();

                ball2 = Instantiate(ballPrefab, new Vector3(-1.4f, -1.25f, 0), Quaternion.identity);
                ball2.GetComponent<BallScript>().speed = 10f;
                ball2.GetComponent<BallScript>().SpawnBall();

                ball3 = Instantiate(ballPrefab, new Vector3(5.6f, 2.46f, 0), Quaternion.identity);
                ball3.GetComponent<BallScript>().speed = 10f;
                ball3.GetComponent<BallScript>().SpawnBall();
                break;

            case 3:
                ball = Instantiate(ballPrefab, new Vector3(3.65f, 0, 0), Quaternion.identity);
                ball.GetComponent<BallScript>().speed = 15f;
                ball.GetComponent<BallScript>().SpawnBall();

                ball2 = Instantiate(ballPrefab, new Vector3(-1.4f, -1.25f, 0), Quaternion.identity);
                ball2.GetComponent<BallScript>().speed = 15f;
                ball2.GetComponent<BallScript>().SpawnBall();

                ball3 = Instantiate(ballPrefab, new Vector3(5.6f, 2.46f, 0), Quaternion.identity);
                ball3.GetComponent<BallScript>().speed = 15f;
                ball3.GetComponent<BallScript>().SpawnBall();
                break;

            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gameStart == false)
        {
            StartGame();
            gameStart = true;
        }

    
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                
                timerIsRunning = false;
                GameManager.instance.NextScene++;
                GameManager.instance.StartGame3();
                timer = 1;
            }
            
        }
    }
}
