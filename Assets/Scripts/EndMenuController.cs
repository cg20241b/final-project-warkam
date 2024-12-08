using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalResultText;

    void Start()
    {
        // Get result from previous scene using PlayerPrefs
        string result = PlayerPrefs.GetString("GameResult");
        finalResultText.text = result;
    }

    public void RetryGame()
    {
        // Load the game scene - replace "GameScene" with your actual game scene name
        SceneManager.LoadScene("GameScene"); 
    }

    public void GoToMainMenu()
    {
        // Quit the game
        SceneManager.LoadScene("MainMenu");
    }

        public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}