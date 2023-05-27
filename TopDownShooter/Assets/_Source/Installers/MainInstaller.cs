using CharacterSystem;
using ScriptableObjects;
using Services;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private BulletPoolSO _bulletPoolSO;
    [SerializeField] private Transform _bulletContainer;

    [SerializeField] private CharacterDataSO _characterDataSO;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Rigidbody2D _characterRb;
    [SerializeField] private Animator _characterAnimator;

    public override void InstallBindings()
    {
        Container.Bind<BulletPool>().AsSingle().NonLazy();
        Container.Bind<BulletPoolSO>().FromInstance(_bulletPoolSO).AsSingle();
        Container.Bind<Transform>().FromInstance(_bulletContainer).AsSingle();

        Container.Bind<CharacterActions>().AsSingle().NonLazy();
        Container.Bind<CharacterDataSO>().FromInstance(_characterDataSO).AsSingle();
        Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
        Container.Bind<Rigidbody2D>().FromInstance(_characterRb).AsSingle();
        Container.Bind<CharacterAnimator>().AsSingle().NonLazy();
        Container.Bind<Animator>().FromInstance(_characterAnimator).AsSingle();

        Container.Bind<LayerService>().AsSingle().NonLazy();

        Container.BindFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(_bulletPoolSO.Bullet);
    }
}