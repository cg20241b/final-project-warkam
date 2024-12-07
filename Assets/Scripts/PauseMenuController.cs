using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private HandTracking handTracking; // Reference to HandTracking script
    private bool isPaused = false;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        // Find HandTracking if not assigned
        if (handTracking == null)
        {
            handTracking = FindObjectOfType<HandTracking>();
        }
    }

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
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Disable hand tracking script
        if (handTracking != null)
        {
            handTracking.enabled = false;
        }
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Re-enable hand tracking script
        if (handTracking != null)
        {
            handTracking.enabled = true;
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}