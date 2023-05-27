using CharacterSystem;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletPoolSO", menuName = "SO/BulletPool", order = 0)]
    public class BulletPoolSO : ScriptableObject
    {
        [SerializeField] private bool _autoExpand;
        [SerializeField] private int _poolLength;
        [SerializeField] private Bullet _bullet;

        public bool AutoExpand { get => _autoExpand; private set { } }
        public int PoolLength { get => _poolLength; private set { } }
        public Bullet Bullet { get => _bullet; private set { } }
    }
}