
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public event System.Action OnGameOver;

    public event System.Action OnMissionSucceed;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        SingletonThisManager();
    }

    private void SingletonThisManager()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



    // This Will start OnGameOver Event which is triggered
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void MissionSucceed()
    {
        OnMissionSucceed?.Invoke();
    }

    public void LoadLevelScene(int levelIndex = 0)
    {
        StartCoroutine(LoadLevelSceneAsync(levelIndex));
    }
    
    private IEnumerator LoadLevelSceneAsync(int levelIndex)
    {
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadMenuSceneAsync());
    }

    private IEnumerator LoadMenuSceneAsync()
    {
        yield return SceneManager.LoadSceneAsync($"Menu");
    }

    public void Exit()
    {
        Debug.Log("App Quit");
        Application.Quit();
    }
}

