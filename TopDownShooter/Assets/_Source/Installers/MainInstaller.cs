using CharacterSystem;
using ScriptableObjects;
using EnemySystem;
using Services;
using UnityEngine;
using Zenject;
using Boosters;
using System.Collections.Generic;
using UI;
using UnityEngine.UI;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private BulletPoolSO _bulletPoolSO;
    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private GameObject _player;
    [SerializeField] private LoseView _loseView;

    [SerializeField] private GameObject _meleeEnemy;
    [SerializeField] private GameObject _shootingEnemy;

    [SerializeField] private CharacterDataSO _characterDataSO;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Rigidbody2D _characterRb;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private Slider _ammo;

    [SerializeField] private BoostersSpawnerSO _boostersSpawnerSO;
    [SerializeField] private List<Transform> _boostersSpawnPoints;

    public override void InstallBindings()
    {
        Container.Bind<BulletPool>().AsSingle().NonLazy();
        Container.Bind<BulletPoolSO>().FromInstance(_bulletPoolSO).AsSingle();
        Container.Bind<Transform>().FromInstance(_bulletContainer).AsSingle();

        Container.Bind<GameObject>().FromInstance(_player).AsSingle();

        Container.Bind<CharacterActions>().AsSingle().NonLazy();
        Container.Bind<CharacterDataSO>().FromInstance(_characterDataSO).AsSingle();
        Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
        Container.Bind<Rigidbody2D>().FromInstance(_characterRb).AsSingle();
        Container.Bind<CharacterAnimator>().AsSingle().NonLazy();
        Container.Bind<Animator>().FromInstance(_characterAnimator).AsSingle();
        Container.Bind<LoseView>().FromInstance(_loseView).AsSingle();
        Container.Bind<Slider>().FromInstance(_ammo).AsSingle();

        Container.Bind<LayerService>().AsSingle().NonLazy();

        Container.Bind<BoostersSpawner>().AsSingle().NonLazy();
        Container.Bind<BoostersSpawnerSO>().FromInstance(_boostersSpawnerSO).AsSingle();
        Container.Bind<List<Transform>>().FromInstance(_boostersSpawnPoints);

        Container.BindFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(_bulletPoolSO.Bullet);
        Container.BindFactory<SpeedBooster, BoostersSpawner.SpeedBoosterFactory>().FromComponentInNewPrefab(_boostersSpawnerSO.SpeedBooster);
        Container.BindFactory<HealthBooster, BoostersSpawner.HealthBoosterFactory>().FromComponentInNewPrefab(_boostersSpawnerSO.HealthBooster);
        Container.BindFactory<MedkitBooster, BoostersSpawner.MedkitBoosterFactory>().FromComponentInNewPrefab(_boostersSpawnerSO.MedkitBooster);
        Container.BindFactory<DamageBooster, BoostersSpawner.DamageBoosterFactory>().FromComponentInNewPrefab(_boostersSpawnerSO.DamageBooster);
        Container.BindFactory<MeleeEnemy, EnemySpawner.MeleeEnemyFactory>().FromComponentInNewPrefab(_meleeEnemy);
        Container.BindFactory<ShootingEnemy, EnemySpawner.ShootingEnemyFactory>().FromComponentInNewPrefab(_shootingEnemy);
    }
}