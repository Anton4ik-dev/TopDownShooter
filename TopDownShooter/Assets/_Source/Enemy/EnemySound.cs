using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource idleSound;
    [SerializeField] private AudioSource deathSound;

    public void PlayIdleSound(bool loop)
    {
        idleSound.loop = loop;
        idleSound.Play();
    }

    public void PlayDeathSound(bool loop)
    {
        Debug.Log("Death");
        deathSound.loop = loop;
        deathSound.Play();
    }

    public void StopIdleSound() => idleSound.Stop();
    public void StopDeathSound() => deathSound.Stop();

}