using System;
using Platforms;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tower
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Tower/TowerGenerationSettings", fileName = "TowerGenerationSettings")]
    public class TowerGenerationSettings : ScriptableObject
    {
        [FormerlySerializedAs("_rotationRange")]
        [Header("Platform rotation")]
        [SerializeField] private Structures.FloatRange rotationFloatRange;
        
        [Header("Platform settings")]
        [SerializeField] [Min(0)] private int _platformVariantCount;
        [SerializeField] [Min(0.0f)] private float _offsetBetweenPlatforms;
        
        [Header("Platform prefabs")]
        [SerializeField] private Platform _startPlatformPrefab;
        [SerializeField] private Platform _lastPlatformPrefab;
        [SerializeField] private Platform[] _platformVariantPrefabs = Array.Empty<Platform>();

        public Structures.FloatRange RotationFloatRange => rotationFloatRange;

        public int PlatformVariantCount => _platformVariantCount;

        public float OffsetBetweenPlatforms => _offsetBetweenPlatforms;

        public Platform StartPlatformPrefab => _startPlatformPrefab;

        public Platform LastPlatformPrefab => _lastPlatformPrefab;

        public Platform[] PlatformVariantPrefabs => _platformVariantPrefabs;
    }
}