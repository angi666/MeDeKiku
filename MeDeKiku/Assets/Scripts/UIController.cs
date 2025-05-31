using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canvasPortada;
    public GameObject canvasLibro;

    void Start()
    {
        // Aseguramos el estado inicial
        canvasPortada.SetActive(true);
        canvasLibro.SetActive(false);
    }

    public void MostrarLibro()
    {
        canvasPortada.SetActive(false);
        canvasLibro.SetActive(true);
    }
}