
using System.Collections;
using UdemyProject.Abstracts.Utilities;
using UdemyProject.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public event System.Action OnGameOver;

    public event System.Action OnMissionSucceed;

    private void Awake()
    {
        SingletonThisGameObject(this);
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
        SoundManager.Instance.StopSound(1);
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
        SoundManager.Instance.PlaySound(0);
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadMenuSceneAsync());
    }

    private IEnumerator LoadMenuSceneAsync()
    {
        SoundManager.Instance.StopSound(0);
        yield return SceneManager.LoadSceneAsync($"Menu");
        SoundManager.Instance.PlaySound(1);
    }

    public void Exit()
    {
        Debug.Log("App Quit");
        Application.Quit();
    }
}

