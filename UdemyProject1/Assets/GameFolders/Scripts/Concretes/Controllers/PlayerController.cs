
using System;
using UdemyProject.Input;
using UdemyProject.Movements;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float _speed;
        private DefaultInput _input;
        private Mover _mover;

        private bool _isForceUp;
        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(GetComponent<Rigidbody>());
        }

        private void Update()
        {
            _isForceUp = _input.IsForceUp;
        }

        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
            }
        }

    }
}

