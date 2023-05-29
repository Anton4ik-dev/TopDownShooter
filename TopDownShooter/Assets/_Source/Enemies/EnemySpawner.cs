using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject meleeEnemy;
    [SerializeField] private GameObject shootingEnemy;
    [SerializeField] private int amountOfMeleeEnemy;
    [SerializeField] private int amountOfShootingEnemy;

    void Start()
    {
        for (int i = 0; i < amountOfMeleeEnemy; i++)
        {
            int rnd = Random.Range(0, spawnPoints.Count);
            Instantiate(meleeEnemy, spawnPoints[rnd].position, Quaternion.identity, spawnPoints[rnd]);
        }
            

        for (int i = 0; i < amountOfShootingEnemy; i++)
        {
            int rnd = Random.Range(0, spawnPoints.Count);
            Instantiate(shootingEnemy, spawnPoints[rnd].position, Quaternion.identity, spawnPoints[rnd]);
        }
            
    }
}
