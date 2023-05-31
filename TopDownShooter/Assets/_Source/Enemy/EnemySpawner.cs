using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EnemySystem
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPoints;
        [SerializeField] private int MaxAmountOfMeleeEnemy;
        [SerializeField] private int MinAmountOfMeleeEnemy;
        [SerializeField] private int MaxAmountOfShootingEnemy;
        [SerializeField] private int MinAmountOfShootingEnemy;

        private MeleeEnemyFactory _meleeEnemyFactory;
        private ShootingEnemyFactory _shootingEnemyFactory;

        void Start()
        {
            int amountOfEnemies = Random.Range(MinAmountOfMeleeEnemy, MaxAmountOfMeleeEnemy + 1);
            for (int i = 0; i < amountOfEnemies; i++)
            {
                int rnd = Random.Range(0, spawnPoints.Count);
                MeleeEnemy meleeEnemy = _meleeEnemyFactory.Create();
                meleeEnemy.gameObject.transform.position = spawnPoints[rnd].position;
                meleeEnemy.gameObject.transform.parent = spawnPoints[rnd];
            }

            amountOfEnemies = Random.Range(MinAmountOfShootingEnemy, MaxAmountOfShootingEnemy + 1);
            for (int i = 0; i < amountOfEnemies; i++)
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