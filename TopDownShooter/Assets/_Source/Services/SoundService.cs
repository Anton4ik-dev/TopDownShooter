using ScriptableObjects;
using UnityEngine;

namespace Services
{
    public class SoundService
    {
        private SoundsSO _soundsSO;
        private AudioSource _audioSource;

        public SoundService(SoundsSO soundsSO, AudioSource audioSource)
        {
            _soundsSO = soundsSO;
            _audioSource = audioSource;
        }

        public SoundsSO Sounds { get => _soundsSO; private set { } }

        public void PlayClip(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}