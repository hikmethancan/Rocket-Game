using System.Collections;
using System.Collections.Generic;
using UdemyProject.Managers;
using UnityEngine;

namespace UdemyProject.Movements
{

    public class Fuel : MonoBehaviour
    {
        [SerializeField] private float _maxFuel = 100f;
        [SerializeField] private float _currentFuel;
        [SerializeField] ParticleSystem _particleSystem;

        public bool IsEmtpy => _currentFuel < 1f;
        public float CurrentFuel => _currentFuel / _maxFuel;
        

        private void Awake()
        {
            _currentFuel = _maxFuel;
        }

        public void FuelIncrease(float increase)
        {
            _currentFuel += increase;
            _currentFuel = Mathf.Min(_currentFuel, _maxFuel);

            if (_particleSystem.isPlaying)
            {
                _particleSystem.Stop();
            }
            SoundManager.Instance.StopSound(2);
        }

        public void FuelDecrease(float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(_currentFuel, 0);

            if (_particleSystem.isStopped)
            {
                _particleSystem.Play();
            }
            SoundManager.Instance.PlaySound(2);
        }
    }

}