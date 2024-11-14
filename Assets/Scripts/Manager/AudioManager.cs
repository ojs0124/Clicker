using UnityEngine;
using Unity.VisualScripting;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource _audioSource;
    private AudioClip[] _audioClips;

    private void Awake()
    {
        this.AddComponent<AudioSource>();
        _audioSource = GetComponent<AudioSource>();
        _audioClips = Resources.LoadAll<AudioClip>("celestial tree sounds");
    }

    void Start()
    {
        _audioSource.clip = _audioClips[3];
        _audioSource.volume = 0.1f;
        _audioSource.Play();
    }
}
