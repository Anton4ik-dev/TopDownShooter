using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterDataSO", menuName = "SO/CharacterData", order = 0)]
    public class CharacterDataSO : ScriptableObject
    {
        [SerializeField] private float _shootDelay;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;
        [SerializeField] private float _moveSpeed;

        public float ShootDelay { get => _shootDelay; private set { } }
        public int MaxHealth { get => _maxHealth; private set { } }
        public int Damage { get => _damage; private set { } }
        public float MoveSpeed { get => _moveSpeed; private set { } }
    }
}