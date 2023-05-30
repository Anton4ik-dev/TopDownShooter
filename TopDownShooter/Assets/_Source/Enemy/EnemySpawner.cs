using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EnemySystem
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPoints;
        [SerializeField] private int amountOfMeleeEnemy;
        [SerializeField] private int amountOfShootingEnemy;

        private MeleeEnemyFactory _meleeEnemyFactory;
        private ShootingEnemyFactory _shootingEnemyFactory;

        void Start()
        {
            for (int i = 0; i < amountOfMeleeEnemy; i++)
            {
                int rnd = Random.Range(0, spawnPoints.Count);
                MeleeEnemy meleeEnemy = _meleeEnemyFactory.Create();
                meleeEnemy.gameObject.transform.position = spawnPoints[rnd].position;
                meleeEnemy.gameObject.transform.parent = spawnPoints[rnd];
            }


            for (int i = 0; i < amountOfShootingEnemy; i++)
            {
                int rnd = Random.Range(0, spawnPoints.Count);
                ShootingEnemy shootingEnemy = _shootingEnemyFactory.Create();
                shootingEnemy.gameObject.transform.position = spawnPoints[rnd].position;
                shootingEnemy.gameObject.transform.parent = spawnPoints[rnd];
            }

        }

        [Inject]
        public void Construct(MeleeEnemyFactory meleeEnemyFactory, ShootingEnemyFactory shootingEnemyFactory)
        {
            _meleeEnemyFactory = meleeEnemyFactory;
            _shootingEnemyFactory = shootingEnemyFactory;
        }

        public class MeleeEnemyFactory : PlaceholderFactory<MeleeEnemy> { }
        public class ShootingEnemyFactory : PlaceholderFactory<ShootingEnemy> { }
    }
}