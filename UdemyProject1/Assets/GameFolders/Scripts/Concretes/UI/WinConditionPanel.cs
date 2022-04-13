using UnityEngine;

namespace UdemyProject.UI
{
    public class WinConditionPanel : MonoBehaviour
    {
        public void YesClicked()
        {
            GameManager.Instance.LoadLevelScene();
        }
    }
}