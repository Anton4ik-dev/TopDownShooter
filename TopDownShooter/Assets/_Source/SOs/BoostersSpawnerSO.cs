using Boosters;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BoosterstSpawnerSO", menuName = "SO/BoostersSpawner", order = 0)]
    public class BoostersSpawnerSO : ScriptableObject
    {
        [SerializeField] private int _minSpeedBoosters;
        [SerializeField] private int _maxSpeedBoosters;
        [SerializeField] private int _minHealthBoosters;
        [SerializeField] private int _maxHealthBoosters;
        [SerializeField] private int _minMedkitBoosters;
        [SerializeField] private int _maxMedkitBoosters;
        [SerializeField] private int _minDamageBoosters;
        [SerializeField] private int _maxDamageBoosters;

        [SerializeField] private SpeedBooster _speedBooster;
        [SerializeField] private HealthBooster _healthBooster;
        [SerializeField] private MedkitBooster _medkitBooster;
        [SerializeField] private DamageBooster _damageBooster;
        
        public int MinSpeedBoosters { get => _minSpeedBoosters; private set { } }
        public int MaxSpeedBoosters { get => _maxSpeedBoosters; private set { } }
        public int MinHealthBoosters { get => _minHealthBoosters; private set { } }
        public int MaxHealthBoosters { get => _maxHealthBoosters; private set { } }
        public int MinMedkitBoosters { get => _minMedkitBoosters; private set { } }
        public int MaxMedkitBoosters { get => _maxMedkitBoosters; private set { } }
        public int MinDamageBoosters { get => _minDamageBoosters; private set { } }
        public int MaxDamageBoosters{ get => _maxDamageBoosters; private set { } }
        public SpeedBooster SpeedBooster{ get => _speedBooster; private set { } }
        public HealthBooster HealthBooster{ get => _healthBooster; private set { } }
        public MedkitBooster MedkitBooster{ get => _medkitBooster; private set { } }
        public DamageBooster DamageBooster{ get => _damageBooster; private set { } }
    }
}