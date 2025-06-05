using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour
{
    [Header("Configuración del Parpadeo")]
    public float blinkInterval = 0.2f;  // Intervalo entre parpadeos

    private Image image;
    private bool isBlinking = false;

    void Awake()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("No se encontró el componente Image.");
        }
    }

    void Start()
    {
        // Inicia el parpadeo automáticamente al iniciar
        StartBlinking();
    }

    public void StartBlinking()
    {
        if (!isBlinking)
            StartCoroutine(BlinkCoroutine());
    }

    private System.Collections.IEnumerator BlinkCoroutine()
    {
        isBlinking = true;

        while (true) // Bucle infinito
        {
            image.enabled = !image.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
