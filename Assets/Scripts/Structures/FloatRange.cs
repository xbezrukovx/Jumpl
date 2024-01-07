using UnityEngine;

namespace Structures
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Structures/FloatRange", fileName = "FloatRange")]
    public class FloatRange : ScriptableObject
    {
        [SerializeField] private float _min;
        [SerializeField] private float _max;

        public float Min => _min;

        public float Max => _max;
        
        
    }
}