using UnityEngine;

namespace Tower
{
    public class TowerRotation : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _rotationSpeed;
        [SerializeField] private Rigidbody _rigidbody;
        public void Rotate(float xAxis)
        {
            Vector3 torque = Vector3.up * xAxis * Time.deltaTime * _rotationSpeed * -1;
            _rigidbody.AddTorque(torque, ForceMode.Acceleration);
        }
    }
}