using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class BulletPool
    {
        private bool _autoExpand;
        private Transform _container;
        private List<Bullet> _pool;
        private Bullet.Factory _bulletFactory;

        public BulletPool(Bullet.Factory bulletFactory, BulletPoolSO bulletPoolSO, Transform container)
        {
            _bulletFactory = bulletFactory;
            _autoExpand = bulletPoolSO.AutoExpand;
            _container = container;

            CreatePool(bulletPoolSO.PoolLength);
        }

        public Bullet GetFreeElement()
        {
            if (HasFreeElement(out Bullet element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new System.Exception("No free elements");
        }

        private void CreatePool(int count)
        {
            _pool = new List<Bullet>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private Bullet CreateObject(bool isActiveByDefault = false)
        {
            Bullet createdObject = _bulletFactory.Create();
            createdObject.gameObject.SetActive(isActiveByDefault);
            createdObject.transform.parent = _container;
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement(out Bullet element)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                {
                    element = _pool[i];
                    _pool[i].transform.position = _container.position;
                    _pool[i].transform.rotation = _container.rotation;
                    _pool[i].gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }
    }
}