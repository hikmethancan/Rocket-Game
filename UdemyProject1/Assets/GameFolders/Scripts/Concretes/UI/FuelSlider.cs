using UdemyProject.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace UdemyProject.UI
{
    public class FuelSlider : MonoBehaviour
    {
        private Slider _slider;
        private Fuel _fuel;
        

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _fuel = FindObjectOfType<Fuel>();
        }

        private void Update()
        {
            _slider.value = _fuel.CurrentFuel;
        }
    }
}