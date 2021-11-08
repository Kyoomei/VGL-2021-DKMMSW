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

    public bool themeIsPlayed;
    public int nextScene = 2;

    public int NextScene
    {
        get{
            return nextScene;
        }
        set{
            nextScene++;
            if (nextScene > 5)
            {
                nextScene = 2;
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

        gameTheme =  GetComponent<AudioSource>();
    }


    

    public void StartGame()
    {
        if (themeIsPlayed == false)
        {
            themeIsPlayed = true;
            gameTheme.Play();
        }
        StartCoroutine(LoadLevel(nextScene));
        
    }
    public void StartGame2()
    {
        if (themeIsPlayed == false)
        {
            themeIsPlayed = true;
            gameTheme.Play();
        }
        StartCoroutine(LoadLevel2(nextScene));
        
    }
    public void StartGame3()
    {
        if (themeIsPlayed == false)
        {
            themeIsPlayed = true;
            gameTheme.Play();
        }
        StartCoroutine(LoadLevel3(nextScene));
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(1);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(2);
        SceneManager.UnloadSceneAsync(1);
    }

    IEnumerator LoadLevel2(int levelIndex)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(1);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(3);
        SceneManager.UnloadSceneAsync(1);
    }

    IEnumerator LoadLevel3(int levelIndex)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(1);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(4);
        SceneManager.UnloadSceneAsync(1);
    }


}
