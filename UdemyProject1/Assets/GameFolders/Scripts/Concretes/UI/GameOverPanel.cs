using UnityEngine;

namespace UdemyProject.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesClicked()
        {
            GameManager.Instance.LoadLevelScene();
        }

        public void NoClicked()
        {
            GameManager.Instance.LoadMenuScene();
        }
    }
}