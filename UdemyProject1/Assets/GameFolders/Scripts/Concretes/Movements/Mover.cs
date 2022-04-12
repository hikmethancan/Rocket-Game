
using UdemyProject.Controllers;
using UnityEngine;

namespace UdemyProject.Movements
{
    public class Mover
    {
        private Rigidbody _rb;
        private PlayerController _playerController;

        public Mover(PlayerController playerController)
        {
            _playerController = playerController;
            _rb = playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick()
        {
            _rb.AddRelativeForce(Vector3.up * Time.deltaTime *_playerController.Force);
        }
    }    
}

