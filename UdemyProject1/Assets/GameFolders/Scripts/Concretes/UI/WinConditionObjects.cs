using System;
using UnityEngine;

namespace UdemyProject.UI
{
    public class WinConditionObjects : MonoBehaviour
    {

        [SerializeField] private GameObject _winConditionPanel;


        private void Awake()
        {
            if (_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(false);
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnMissionSucceed += HandleOnMissionSucceed;
        }

        private void HandleOnMissionSucceed()
        {
            if (!_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(true);
            }
        }

        private void OnDisable()
        {
            GameManager.Instance.OnMissionSucceed -= HandleOnMissionSucceed;
        }
    }
}