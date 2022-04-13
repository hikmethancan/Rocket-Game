using UdemyProject.Controllers;
using UnityEngine;

namespace UdemyProject.Abstracts.Controllers
{

    public abstract class WallController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            var player = collision.collider.GetComponent<PlayerController>();

            if (player != null && player.CanMove)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

}