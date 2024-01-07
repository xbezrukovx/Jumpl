using System;
using UnityEngine;

namespace Ball
{
    public class BallEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _collisionParticlesPrefab;
        private void OnCollisionEnter(Collision other)
        {
            Vector3 hitPoint = other.contacts[0].point;
            EmitCollisionParticles(hitPoint);
        }

        private void EmitCollisionParticles(Vector3 hitPoint)
        {
            Instantiate(_collisionParticlesPrefab, hitPoint, Quaternion.identity);
        }
    }
}