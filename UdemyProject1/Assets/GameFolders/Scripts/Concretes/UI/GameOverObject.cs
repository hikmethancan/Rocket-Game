using UnityEngine;

namespace UdemyProject.UI
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;

        private void Awake()
        {
            if (_gameOverPanel.activeSelf)
            {
                _gameOverPanel.SetActive(false);
            }
        }


        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleGameOver;
        }


        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleGameOver;
        }

        private void HandleGameOver()
        {
            if (!_gameOverPanel.activeSelf)
            {
                _gameOverPanel.SetActive(true);
            }
        }
    }
}