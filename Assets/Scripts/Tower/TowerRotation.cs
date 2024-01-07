using UnityEngine;

namespace Tower
{
    public class TowerRotation : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _rotationSpeed;
        private Quaternion _newRotation;

        private void Update()
        {
            transform.rotation = CalculateRotation(Time.deltaTime * _rotationSpeed);
        }

        private Quaternion CalculateRotation(float rotationSpeed)
        {
            return Quaternion.Slerp(transform.rotation, _newRotation, rotationSpeed);
        }

        public void AddRotation(float xAxis)
        {
            Vector3 newEulerRotationAngle = transform.eulerAngles + Vector3.down * xAxis;
            _newRotation = Quaternion.Euler(newEulerRotationAngle);
        }
    }
}