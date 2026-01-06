using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    
    [Header("Music")]
    public AudioClip backgroundMusic;

    [Header("Clips")]
    public AudioClip jumpClip;
    public AudioClip drawClip;
    public AudioClip hitClip;
    public AudioClip levelCompleteClip;
    public AudioClip collectiblePickedClip;

      void Awake()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }


    void OnEnable()
    {
        GameEvents.OnPlayerJump += PlayJump;
        GameEvents.OnDrawStart += PlayDraw;
        GameEvents.OnPlayerDied += PlayHit;
        GameEvents.OnLevelFinished += PlayLevelComplete;
        GameEvents.OnCollectiblePicked += PlayCollectiblePicked;
    }  

    void OnDisable()
    {
        GameEvents.OnPlayerJump -= PlayJump;
        GameEvents.OnDrawStart -= PlayDraw;
        GameEvents.OnPlayerDied -= PlayHit;
        GameEvents.OnLevelFinished -= PlayLevelComplete;
        GameEvents.OnCollectiblePicked -= PlayCollectiblePicked;
    }

    void PlayJump() => Play(jumpClip);
    void PlayDraw() => Play(drawClip);
    void PlayHit() => Play(hitClip);
    void PlayLevelComplete() => Play(levelCompleteClip);
    void PlayCollectiblePicked() => Play(collectiblePickedClip);

    void Play(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }
}
