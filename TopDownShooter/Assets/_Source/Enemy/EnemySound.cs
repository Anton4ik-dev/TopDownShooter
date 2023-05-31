using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource idleSound;
    [SerializeField] private AudioSource deathSound;

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            StopIdleSound();
            StopDeathSound();
        }
        else
            PlayIdleSound(true);
    }

    public void PlayIdleSound(bool loop)
    {
        idleSound.loop = loop;
        idleSound.Play();
    }

    public void PlayDeathSound(bool loop)
    {
        deathSound.loop = loop;
        deathSound.Play();
    }

    public void StopIdleSound() => idleSound.Stop();
    public void StopDeathSound() => deathSound.Stop();

}
