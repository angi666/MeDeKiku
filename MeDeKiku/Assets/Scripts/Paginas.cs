using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    [Header("Lista de páginas en orden")]
    public List<GameObject> pages;

    [Header("Botones de navegación")]
    public Button nextButton;
    public Button previousButton;

    private int currentPageIndex = 0;

    void Start()
    {
        // Asegurarse de que todas las páginas estén desactivadas excepto la primera
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(i == currentPageIndex);
        }

        // Asignar funciones a los botones
        if (nextButton != null)
            nextButton.onClick.AddListener(NextPage);

        if (previousButton != null)
            previousButton.onClick.AddListener(PreviousPage);
    }

    public void NextPage()
    {
        if (currentPageIndex < pages.Count - 1)
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex++;
            pages[currentPageIndex].SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex--;
            pages[currentPageIndex].SetActive(true);
        }
    }
}
