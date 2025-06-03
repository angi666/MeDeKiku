using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorChanger : MonoBehaviour
{
    public Image panelImage; // Asigna el panel aquí desde el Inspector
    public Color[] colors;   // Lista de colores entre los que cambiar
    public float changeDuration = 2f; // Tiempo entre transiciones

    private int currentIndex = 0;
    private float timer = 0f;

    void Update()
    {
        if (colors.Length < 2) return;

        timer += Time.deltaTime;
        float t = timer / changeDuration;

        Color currentColor = colors[currentIndex];
        Color nextColor = colors[(currentIndex + 1) % colors.Length];

        panelImage.color = Color.Lerp(currentColor, nextColor, t);

        if (t >= 1f)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            timer = 0f;
        }
    }
}
