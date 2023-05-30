using EnemySystem;
using Services;
using System.Collections;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _lifeTime;
        [SerializeField] private LayerMask _characterLayer;
        [SerializeField] private LayerMask _enemyLayer;

        private int _damage;

        [Inject]
        private LayerService _layerService;

        public int Damage
        {
            get => _damage;
            set
            {
                _damage = value;
            }
        }

        private void Awake()
        {
            if(_rb == null)
                _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rb.velocity = transform.up * _speed;
        }

        private void OnEnable()
        {
            StartCoroutine(LifeTime());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _enemyLayer))
            {
                if (collision.gameObject.TryGetComponent(out IEnemy enemy))
                    enemy.GetDamage(_damage);
                gameObject.SetActive(false);
            }
            if (collision.gameObject.layer == gameObject.layer || _layerService.CheckLayersEquality(collision.gameObject.layer, _characterLayer))
                return;
            
            gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(LayerService layerService)
        {
            _layerService = layerService;
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);
            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<Bullet> { }
    }
}