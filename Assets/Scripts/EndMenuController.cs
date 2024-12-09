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
        SceneManager.LoadScene("GameScene"); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

        public void QuitGame()
    {
        Application.Quit();
    }
}