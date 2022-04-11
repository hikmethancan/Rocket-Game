using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject.Controllers;

namespace UdemyProject.Movements
{

    public class Rotator
    {
        Rigidbody _rb;
        PlayerController _playerController;

        public Rotator(PlayerController playerController)
        {
            _playerController = playerController;
            _rb = playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick(float direction)
        {
            if (direction == 0)
            {
                if (_rb.freezeRotation)
                {
                    _rb.freezeRotation = false;
                    return;
                }
            }

            if (!_rb.freezeRotation) _rb.freezeRotation = true;

            _playerController.transform.Rotate(_playerController.TurnSpeed * direction * Time.deltaTime * Vector3.back);
        }

    }

}