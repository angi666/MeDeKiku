using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paginas : MonoBehaviour
{
    [Header("Lista de páginas en orden")]
    public List<GameObject> pages;

    [Header("Botones de navegación")]
    public Button nextButton;
    public Button previousButton;

    [Header("Transición")]
    public float transitionDuration = 0.5f;

    private int currentPageIndex = 0;
    private bool isTransitioning = false;

    void Start()
    {
        // Inicializa todas las páginas, activa solo la primera
        for (int i = 0; i < pages.Count; i++)
        {
            CanvasGroup cg = pages[i].GetComponent<CanvasGroup>();
            if (cg != null)
            {
                cg.alpha = i == currentPageIndex ? 1 : 0;
                pages[i].SetActive(true); // Activar siempre para permitir animaciones
            }
            else
            {
                Debug.LogWarning($"La página {pages[i].name} no tiene CanvasGroup.");
            }
        }

        nextButton.onClick.AddListener(NextPage);
        previousButton.onClick.AddListener(PreviousPage);
    }

    public void NextPage()
    {
        if (currentPageIndex < pages.Count - 1 && !isTransitioning)
        {
            StartCoroutine(TransitionToPage(currentPageIndex + 1));
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0 && !isTransitioning)
        {
            StartCoroutine(TransitionToPage(currentPageIndex - 1));
        }
    }

    private IEnumerator TransitionToPage(int newPageIndex)
    {
        isTransitioning = true;

        CanvasGroup current = pages[currentPageIndex].GetComponent<CanvasGroup>();
        CanvasGroup next = pages[newPageIndex].GetComponent<CanvasGroup>();

        if (current == null || next == null)
        {
            Debug.LogError("Todas las páginas deben tener CanvasGroup.");
            yield break;
        }

        // Opcional: activar la nueva página antes de hacer fade-in si está desactivada
        // pages[newPageIndex].SetActive(true);

        // Fade out página actual
        float t = 0f;
        while (t < transitionDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / transitionDuration);
            current.alpha = alpha;
            yield return null;
        }
        current.alpha = 0;

        // Opcional: desactivar la página saliente si quieres pausar animaciones
        // pages[currentPageIndex].SetActive(false);

        // Cambiar índice actual
        currentPageIndex = newPageIndex;

        // Fade in nueva página
        t = 0f;
        while (t < transitionDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / transitionDuration);
            next.alpha = alpha;
            yield return null;
        }
        next.alpha = 1;

        isTransitioning = false;
    }
}
