
using System;
using UdemyProject.Input;
using UdemyProject.Movements;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float _speed;
        [SerializeField] private float _turnSpeed;
        [SerializeField] private float _force;

        private DefaultInput _input;
        private Mover _mover;
        private Rotator _rotator;
        private Fuel _fuel;

        private bool _canMove;
        private bool _isForceUp;
        private float _leftRight;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;

        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fuel = GetComponent<Fuel>();
        }

        private void Start()
        {
            _canMove = true;
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleEventTriggered;
        }


        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleEventTriggered;
        }

        

        private void Update()
        {
            if (!_canMove) return;

            if (_input.IsForceUp && !_fuel.IsEmtpy)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
                _fuel.FuelIncrease(.01f);
            }

            _leftRight = _input.LeftRight;
        }

        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
            }

            _rotator.FixedTick(_leftRight);
        }
        private void HandleEventTriggered()
        {
            _canMove = false;
            _isForceUp = false;
            _leftRight = 0f;
            _fuel.FuelIncrease(0);
        }

    }
}

