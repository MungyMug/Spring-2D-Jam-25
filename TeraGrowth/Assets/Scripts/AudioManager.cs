using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip background;
    public AudioClip shake;
    public AudioClip croak;
    public AudioClip water;
    public AudioClip slug;
    public AudioClip flip;
    public AudioClip yawn;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clipName)
    {
        sfxSource.PlayOneShot(clipName);
    }

    public void PlayFlip()
    {
        sfxSource.PlayOneShot(flip);
    }
}
