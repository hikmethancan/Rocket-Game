using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject.Controllers
{

    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] private GameObject _finishFireWork;
        [SerializeField] private GameObject _finishLight;

        private void OnCollisionEnter(Collision collision)
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            if (player == null) return;
            //collision.GetContact(0).normal.y == -1f  => !!! This Code checks if 
            if (collision.GetContact(0).normal.y == -1f)
            {
                _finishLight.gameObject.SetActive(true);
                _finishFireWork.gameObject.SetActive(true);
            }
            else
            {
                // GameOver
                GameManager.Instance.GameOver();
            }
        }

    }

}