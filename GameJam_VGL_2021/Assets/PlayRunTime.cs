using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayRunTime : MonoBehaviour
{

    private VideoPlayer MyVideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        MyVideoPlayer = GetComponent<VideoPlayer>();
        // play video player
        MyVideoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
