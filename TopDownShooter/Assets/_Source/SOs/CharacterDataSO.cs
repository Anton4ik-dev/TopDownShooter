using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterDataSO", menuName = "SO/CharacterData", order = 0)]
    public class CharacterDataSO : ScriptableObject
    {
        [SerializeField] private float _shootDelay;
        [SerializeField] private int _health;
        [SerializeField] private float _moveSpeed;

        public float ShootDelay { get => _shootDelay; private set { } }
        public int Health { get => _health; private set { } }
        public float MoveSpeed { get => _moveSpeed; private set { } }
    }
}