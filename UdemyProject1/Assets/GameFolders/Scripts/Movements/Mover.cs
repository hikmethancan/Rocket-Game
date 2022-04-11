
using UnityEngine;

namespace UdemyProject.Movements
{
    public class Mover
    {
        private Rigidbody _rb;

        public Mover(Rigidbody rigidBody)
        {
            _rb = rigidBody;
        }

        public void FixedTick()
        {
            _rb.AddRelativeForce(Vector3.up * Time.deltaTime * 55f);
        }
    }    
}

