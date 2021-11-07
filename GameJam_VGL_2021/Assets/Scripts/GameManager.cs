using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject animTransition;

    AudioSource gameTheme;

    public float transitionTime;
    int score;
    public int loop;

    bool themeIsPlayed;
    int nextScene = 1;

    public int NextScene
    {
        get{
            return nextScene;
        }
        set{
            nextScene++;
            if (nextScene == 5)
            {
                nextScene = 1;
            }
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }


    

    public void StartGame()
    {
        if (themeIsPlayed == false)
        {
            themeIsPlayed = true;
            gameTheme.Play();
        }
        StartCoroutine(LoadLevel(nextScene + 1));
        NextScene++;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(1);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(levelIndex);
        SceneManager.UnloadSceneAsync(1);
    }

}
