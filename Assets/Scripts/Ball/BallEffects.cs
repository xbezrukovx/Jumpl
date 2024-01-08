using System;
using UnityEngine;

namespace Ball
{
    public class BallEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _collisionParticlesPrefab;
        [SerializeField] private ParticleSystem _destroyParticlesPrefab;

        public void EmitCollisionParticles(Vector3 hitPoint)
        {
            Instantiate(_collisionParticlesPrefab, hitPoint, Quaternion.identity);
        }

        public void EmitDestroyParticles(Vector3 hitpoint)
        {
            Instantiate(_destroyParticlesPrefab, hitpoint, Quaternion.identity);
        }
    }
}