using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Canvases")]
    public GameObject canvasPortada;
    public GameObject canvasLibro;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No hay AudioSource en este GameObject");
        }
    }

    public void OnButtonClicked()
    {
        StartCoroutine(PlaySoundAndThenOpen());
    }

    private IEnumerator PlaySoundAndThenOpen()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        else
        {
            Debug.LogWarning("AudioSource o clip no asignado.");
        }

        if (canvasPortada != null)
        {
            canvasPortada.SetActive(false);
        }

        if (canvasLibro != null)
        {
            canvasLibro.SetActive(true);
        }
    }
}
