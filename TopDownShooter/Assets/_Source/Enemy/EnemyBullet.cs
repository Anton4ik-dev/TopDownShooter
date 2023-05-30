using CharacterSystem;
using System.Collections;
using UnityEngine;
using Zenject;

namespace EnemySystem
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float fireForce;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private LayerMask bulletLayer;
        [SerializeField] private float _lifeTime;

        private int _damage;
        private int _enemyLayerMask;
        private int _bulletLayerMask;

        private void Awake()
        {
            _enemyLayerMask = (int)Mathf.Log(playerLayer.value, 2);
            _bulletLayerMask = (int)Mathf.Log(bulletLayer.value, 2);
        }

        private void OnEnable()
        {
            StartCoroutine(LifeTime());
        }

        private void Update()
        {
            rb.velocity = transform.up * fireForce;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _enemyLayerMask)
                collision.GetComponent<CharacterView>().Health -= _damage;

            if (collision.gameObject.layer != _bulletLayerMask)
                gameObject.SetActive(false);
        }

        public void SetDamage(int damage) => _damage = damage;

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);
            gameObject.SetActive(false);
        }
    }
}