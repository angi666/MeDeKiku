using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // arrastra aquí el Canvas desde el Inspector
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Pausa la física y animaciones
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
        isPaused = false;
    }
}
