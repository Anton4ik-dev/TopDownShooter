using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundsSO", menuName = "SO/Sounds", order = 0)]
    public class SoundsSO : ScriptableObject
    {
        [SerializeField] private AudioClip _shootClip;

        public AudioClip ShootClip { get => _shootClip; private set { } }
    }
}