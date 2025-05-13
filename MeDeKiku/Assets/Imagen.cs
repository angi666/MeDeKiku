using UnityEngine;
using UnityEngine.UI;

public class CambiarImagen : MonoBehaviour
{
    [Header("Im�genes que se alternan")]
    public GameObject imagen1;
    public GameObject imagen2;

    [Header("Bot�n que activa el cambio")]
    public Button boton;

    void Start()
    {
        if (boton != null)
        {
            // Asigna el m�todo AlternarImagenes al bot�n desde el script
            boton.onClick.AddListener(AlternarImagenes);
        }
        else
        {
            Debug.LogWarning("No has asignado un bot�n en el Inspector.");
        }
    }

    public void AlternarImagenes()
    {
        if (imagen1 != null && imagen2 != null)
        {
            bool estadoImagen1 = imagen1.activeSelf;

            imagen1.SetActive(!estadoImagen1);
            imagen2.SetActive(estadoImagen1); // Contrario
        }
        else
        {
            Debug.LogWarning("Debes asignar ambas im�genes en el Inspector.");
        }
    }
}
