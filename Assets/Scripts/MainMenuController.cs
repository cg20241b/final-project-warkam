using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // [SerializeField]
    // private Button playButton;
    // [SerializeField]
    // private Button quitButton;

    // void Start()
    // {
    //     // Add listeners to buttons
    //     playButton.onClick.AddListener(PlayGame);
    //     quitButton.onClick.AddListener(QuitGame);
    // }

    public void PlayGame()
    {
        // Load the game scene - replace "GameScene" with your actual game scene name
        SceneManager.LoadScene("GameScene"); 
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}