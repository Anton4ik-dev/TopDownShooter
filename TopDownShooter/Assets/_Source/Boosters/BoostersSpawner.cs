using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Boosters
{
    public class BoostersSpawner
    {
        private List<Transform> _containers;
        private BoostersSpawnerSO _boostersSpawnerSO;
        private SpeedBoosterFactory _speedBoosterFactory;
        private HealthBoosterFactory _healthBoosterFactory;
        private MedkitBoosterFactory _medkitBoosterFactory;
        private DamageBoosterFactory _damageBoosterFactory;
        private int _counter = 0;

        public BoostersSpawner(SpeedBoosterFactory speedBoosterFactory,
            HealthBoosterFactory healthBoosterFactory,
            MedkitBoosterFactory medkitBoosterFactory,
            DamageBoosterFactory damageBoosterFactory,
            BoostersSpawnerSO boostersSpawnerSO,
            List<Transform> containers)
        {
            _speedBoosterFactory = speedBoosterFactory;
            _healthBoosterFactory = healthBoosterFactory;
            _medkitBoosterFactory = medkitBoosterFactory;
            _damageBoosterFactory = damageBoosterFactory;
            _boostersSpawnerSO = boostersSpawnerSO;
            _containers = containers;

            SpawnBoosters();
        }

        private void SpawnBoosters()
        {
            for (int i = 0; i < Random.Range(_boostersSpawnerSO.MinSpeedBoosters, _boostersSpawnerSO.MaxSpeedBoosters); i++)
            {
                CreateSpeedBoosters();
                _counter++;
            }
            for (int i = 0; i < Random.Range(_boostersSpawnerSO.MinHealthBoosters, _boostersSpawnerSO.MaxHealthBoosters); i++)
            {
                CreateHealthBoosters();
                _counter++;
            }
            for (int i = 0; i < Random.Range(_boostersSpawnerSO.MinMedkitBoosters, _boostersSpawnerSO.MaxMedkitBoosters); i++)
            {
                CreateMedkitBoosters();
                _counter++;
            }
            for (int i = 0; i < Random.Range(_boostersSpawnerSO.MinDamageBoosters, _boostersSpawnerSO.MaxDamageBoosters); i++)
            {
                CreateDamageBoosters();
                _counter++;
            }
        }

        private void CreateSpeedBoosters()
        {
            SpeedBooster createdObject = _speedBoosterFactory.Create();
            SetPosition(createdObject);
        }

        private void CreateHealthBoosters()
        {
            HealthBooster createdObject = _healthBoosterFactory.Create();
            SetPosition(createdObject);
        }

        private void CreateMedkitBoosters()
        {
            MedkitBooster createdObject = _medkitBoosterFactory.Create();
            SetPosition(createdObject);
        }

        private void CreateDamageBoosters()
        {
            DamageBooster createdObject = _damageBoosterFactory.Create();
            SetPosition(createdObject);
        }

        private void SetPosition(ABooster createdObject)
        {
            createdObject.transform.parent = _containers[_counter];
            createdObject.transform.position = _containers[_counter].position;
            createdObject.transform.rotation = _containers[_counter].rotation;
        }

        public class SpeedBoosterFactory : PlaceholderFactory<SpeedBooster> { }
        public class HealthBoosterFactory : PlaceholderFactory<HealthBooster> { }
        public class MedkitBoosterFactory : PlaceholderFactory<MedkitBooster> { }
        public class DamageBoosterFactory : PlaceholderFactory<DamageBooster> { }
    }
}