using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _kioskErrorSound;

    internal void PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
    }
}
