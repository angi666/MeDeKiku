using System.Collections;
using UnityEngine;

public class FadeInImagenes : MonoBehaviour
{
    public CanvasGroup[] imagenes;      // Las imágenes para hacer fade-in simultáneo
    public float duracionFade = 1f;     // Duración del fade

    private bool yaEmpezo = false;

    void Start()
    {
        foreach (var img in imagenes)
        {
            if (img != null)
            {
                img.alpha = 0f;
                img.interactable = false;
                img.blocksRaycasts = false;
            }
        }
    }

    void OnEnable()
    {
        if (!yaEmpezo)
        {
            yaEmpezo = true;
            StartCoroutine(FadeSimultaneo());
        }
    }

    void OnDisable()
    {
        yaEmpezo = false;

        foreach (var img in imagenes)
        {
            if (img != null)
            {
                img.alpha = 0f;
                img.interactable = false;
                img.blocksRaycasts = false;
            }
        }
    }

    IEnumerator FadeSimultaneo()
    {
        float t = 0f;

        while (t < duracionFade)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01(t / duracionFade);

            foreach (CanvasGroup img in imagenes)
            {
                if (img == null) continue;
                img.alpha = alpha;
            }

            yield return null;
        }

        // Asegurar que todas queden a alpha=1 y activas para interacción
        foreach (CanvasGroup img in imagenes)
        {
            if (img == null) continue;
            img.alpha = 1f;
            img.interactable = true;
            img.blocksRaycasts = true;
        }
    }
}
