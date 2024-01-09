using System;
using System.Collections;
using System.Runtime.Remoting.Activation;
using Platforms;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Ball
{
    public class BallCollisions : MonoBehaviour
    {
        [SerializeField] private BallBounce _Bounce;
        [FormerlySerializedAs("_Effects")] [SerializeField] private BallEffects _effects;

        private bool _collided;
        private void OnCollisionEnter(Collision other)
        {
            Vector3 hitPoint = other.contacts[0].point;
            if (other.gameObject.TryGetComponent(out PlatformObstacle _))
            {
                Destroy(hitPoint);
                return;
            }
            if (_collided)
            {
                return;
            }

            _collided = true;
            _effects.EmitCollisionParticles(hitPoint);
            _Bounce.BounceOff();
        }

        private void OnCollisionExit(Collision other)
        {
            _collided = false;
        }

        private void Destroy(Vector3 hitpoint)
        {
            _effects.EmitDestroyParticles(hitpoint);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}