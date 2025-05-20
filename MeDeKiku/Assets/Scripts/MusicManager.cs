using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Audio Clip de Música de Fondo")]
    public AudioClip backgroundMusicClip;

    [Header("Configuración")]
    [Range(0f, 1f)]
    public float volume = 0.5f;
    public bool loopMusic = true;
    public bool playOnAwake = true;

    private AudioSource audioSource;

    void Awake()
    {
        // Asegura que solo haya una instancia de MusicManager
        // Esto es útil si cargas escenas aditivamente
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Persiste el objeto entre escenas

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = backgroundMusicClip;
        audioSource.volume = volume;
        audioSource.loop = loopMusic;

        if (playOnAwake)
        {
            PlayMusic();
        }
    }

    public void PlayMusic()
    {
        if (backgroundMusicClip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume); // CORRECTED: Changed Clamp001 to Clamp01
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}