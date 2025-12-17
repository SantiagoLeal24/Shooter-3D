using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource shootingSound;
    public AudioSource reloadingSound;
    public AudioSource EmptyMagazineSound;

    public AudioClip backgroundMusic;
    [Range(0f, 1f)] public float musicVolume = 0.3f;

    private AudioSource musicSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (backgroundMusic != null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();

            musicSource.clip = backgroundMusic;

            musicSource.loop = true;

            musicSource.spatialBlend = 0f;

            musicSource.volume = musicVolume;

            musicSource.Play();    
        }
    }
}
