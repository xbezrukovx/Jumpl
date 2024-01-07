using System;
using System.Collections.Generic;
using Extentions;
using Platforms;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private TowerGenerationSettings _settings;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            List<Platform> spawnedPlatforms = SpawnPlatforms(out float offsetFromTop);
            FitTowerHeight(offsetFromTop);
            spawnedPlatforms.ForEach(platform => platform.transform.SetParent(this.transform));
        }

        private List<Platform> SpawnPlatforms(out float offsetFromTop)
        {
            const int firstAndLastPlatformsCount = 2;
            List<Platform> spawnedPlatforms = new List<Platform>(_settings.PlatformVariantCount + firstAndLastPlatformsCount);
            offsetFromTop = _settings.OffsetBetweenPlatforms;
            Platform firstPlatform = Create(_settings.StartPlatformPrefab, offsetFromTop);
            spawnedPlatforms.Add(firstPlatform);
            offsetFromTop += _settings.StartPlatformPrefab.transform.localScale.y + _settings.OffsetBetweenPlatforms;
            
            for (int i = 0; i < _settings.PlatformVariantCount; i++)
            {
                Platform platform = Create(_settings.PlatformVariantPrefabs.Random(), offsetFromTop);
                spawnedPlatforms.Add(platform);
                offsetFromTop += _settings.StartPlatformPrefab.transform.localScale.y + _settings.OffsetBetweenPlatforms;
            }

            Platform lastPlatform = Create(_settings.LastPlatformPrefab, offsetFromTop);
            spawnedPlatforms.Add(lastPlatform);
            offsetFromTop += _settings.StartPlatformPrefab.transform.localScale.y + _settings.OffsetBetweenPlatforms;
            
            return spawnedPlatforms;
        }

        private Vector3 GetRandomYRotation()
        {
            return Vector3.up * Random.Range(_settings.RotationFloatRange.Min, _settings.RotationFloatRange.Max);
        }

        private Platform Create(Platform platformPrefab, float offsetFromTop)
        {
            Platform platform = Instantiate(platformPrefab);
            platform.transform.position = Vector3.down * offsetFromTop;
            platform.transform.eulerAngles = GetRandomYRotation();
            return platform;
        }

        private void FitTowerHeight(float height)
        {
            Vector3 originalSize = this.transform.localScale;
            float targetHeight = height / 2.0f;
            this.transform.localScale = new Vector3(originalSize.x, targetHeight, originalSize.z);
            this.transform.localPosition -= Vector3.up * targetHeight;
        }
    }
}