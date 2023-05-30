using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyBulletPool
    {
        private Transform _container;
        private List<EnemyBullet> _pool;
        private GameObject _bulletPrefab;

        public EnemyBulletPool(int poolSize, GameObject bulletPrefab, Transform container)
        {
            _container = container;
            _bulletPrefab = bulletPrefab;
            CreatePool(poolSize);
        }

        public EnemyBullet GetFreeElement(int damage)
        {
            if (HasFreeElement(damage, out EnemyBullet element))
                return element;
            else
                return CreateObject(damage, false);
        }

        private void CreatePool(int count)
        {
            _pool = new List<EnemyBullet>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private EnemyBullet CreateObject(int damage = 0, bool isActiveByDefault = false)
        {
            GameObject enemyBullet = Object.Instantiate(_bulletPrefab, _container.position, Quaternion.identity, _container);
            _bulletPrefab.SetActive(isActiveByDefault);
            _pool.Add(enemyBullet.GetComponent<EnemyBullet>());
            _pool[_pool.Count - 1].SetDamage(damage);
            return _pool[_pool.Count-1];
        }

        private bool HasFreeElement(int damage, out EnemyBullet element)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                {
                    element = _pool[i];
                    _pool[i].transform.position = _container.position;
                    _pool[i].transform.rotation = _container.rotation;
                    _pool[i].SetDamage(damage);
                    _pool[i].gameObject.SetActive(true);
                    _pool[i].gameObject.transform.parent = _container.parent.parent;
                    return true;
                }
            }

            element = null;
            return false;
        }
    }
}