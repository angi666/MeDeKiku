using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con el componente Button

public class ButtonSoundPlayer : MonoBehaviour
{
    [Header("Clip de Sonido del Bot�n")]
    public AudioClip buttonClickSound;

    [Header("Configuraci�n del Sonido")]
    [Range(0f, 1f)]
    public float volume = 0.7f; // Volumen para este sonido espec�fico

    private AudioSource audioSource; // Un AudioSource para reproducir este sonido

    void Awake()
    {
        // Obtener o a�adir un AudioSource si no existe
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configurar el AudioSource para el sonido del bot�n
        audioSource.playOnAwake = false; // No queremos que suene al iniciar
        audioSource.loop = false;       // No queremos que se repita
        audioSource.volume = volume;
        audioSource.clip = buttonClickSound; // Asignar el clip de sonido

        // Si este script est� en el mismo GameObject que un bot�n, podemos a�adir el listener autom�ticamente
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    /// <summary>
    /// Reproduce el sonido del bot�n asignado.
    /// </summary>
    public void PlaySound()
    {
        if (buttonClickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonClickSound, volume);
            // Usamos PlayOneShot para que el sonido se reproduzca una vez y no sea interrumpido
            // si el bot�n se presiona r�pidamente de nuevo.
        }
    }

    /// <summary>
    /// M�todo para actualizar el volumen si se cambia en el Inspector en tiempo de ejecuci�n.
    /// </summary>
    void OnValidate()
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}