
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public event System.Action OnGameOver;
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
}

