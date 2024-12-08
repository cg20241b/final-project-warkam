using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro; // Add this namespace
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Game state
    public int playerLives = 3;
    public int aiLives = 3;
    public string playerMove = "";
    public string aiMove = "";
    public string result = "";

    // Add countdown value for Inspector visibility
    [SerializeField] 
    private int currentCountdown = 5;

    // UI Elements
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI resultText;
    //public TextMeshProUGUI scoreText;
    public TextMeshProUGUI currentGestureText;
    // public TextMeshProUGUI livesCountdownText; // Add new UI text element
    [SerializeField] private TextMeshProUGUI playerGestureText; // Add this field

    public TextMeshProUGUI enemyGestureText; // Add this field

    // Health UI Images
    [Header("Player Health UI")]
    [SerializeField] private Image playerHealth1;
    [SerializeField] private Image playerHealth2;
    [SerializeField] private Image playerHealth3;

    [Header("Enemy Health UI")]
    [SerializeField] private Image enemyHealth1;
    [SerializeField] private Image enemyHealth2;
    [SerializeField] private Image enemyHealth3;

    [Header("Current Gesture")]
    [SerializeField] private string currentGesture;  // Shows in Inspector

    // Change to property with private backing field
    private bool _isRoundActive = false;
    public bool IsRoundActive { get { return _isRoundActive; } private set { _isRoundActive = value; } }
    
    private bool isTie = false;

    // Reference to UDPReceive
    public UDPReceive udpReceive;

    [SerializeField] private HandAnimationController aiHandAnimation;

    void Start()
    {   
        // Ensure UDP connection is started fresh
        if (udpReceive != null)
        {
            udpReceive.StartUDP();
        }

        IsRoundActive = true;

        StartCoroutine(GameRound());
    }

    void Update()
    {
        // Update gesture text from UDP receiver
        if (udpReceive != null && playerGestureText != null && !string.IsNullOrEmpty(udpReceive.currentGesture))
        {
            string gesture = udpReceive.currentGesture;
            playerGestureText.text = gesture.Substring(1, gesture.Length - 2);
            
            // Update currentGestureText if it exists (for backward compatibility)
            if (currentGestureText != null)
            {
                currentGestureText.text = $"{gesture}".Substring(1, gesture.Length - 2);
            }
        }
    }

    private IEnumerator GameRound()
    {
        IsRoundActive = true;  // Use property instead of field
        resultText.text = "";

        // Countdown with Inspector visibility
        for (currentCountdown = 5; currentCountdown >= 1; currentCountdown--)
        {
            countdownText.text = currentCountdown.ToString();
            // if (livesCountdownText != null)
            // {
            //     livesCountdownText.text = $"Countdown: {currentCountdown}";
            // }
            yield return new WaitForSeconds(1f);
        }
        
        countdownText.text = "GO!";
        // if (livesCountdownText != null)
        // {
        //     livesCountdownText.text = "GO!";
        // }
        yield return new WaitForSeconds(1f);
        
        // Capture player's move from UDP
        playerMove = udpReceive.currentGesture;
        countdownText.text = "";

        // Get AI move
        aiMove = GetAIMove();
        enemyGestureText.text = aiMove;

        if(aiHandAnimation != null)
        {
            aiHandAnimation.SetGesture(aiMove);
        }

        // Determine winner
        DetermineRoundWinner();
        //UpdateScore();

        // Wait for spacebar
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        
        if (isTie)
        {
            StartCoroutine(GameRound()); // Restart if tie
        }
        else if (playerLives == 0 || aiLives == 0)
        {
            EndGame();
        }
        else
        {
            StartCoroutine(GameRound()); // Next round
        }
    }

    private void DetermineRoundWinner()
    {   
        if(playerMove != "") {
            if (playerMove.Substring(1, playerMove.Length - 2) == aiMove)
            {
                result = "Tie!";
                isTie = true;
            }
            else if ((playerMove.Substring(1, playerMove.Length - 2) == "Rock" && aiMove == "Scissors") ||
                    (playerMove.Substring(1, playerMove.Length - 2) == "Paper" && aiMove == "Rock") ||
                    (playerMove.Substring(1, playerMove.Length - 2) == "Scissors" && aiMove == "Paper"))
            {
                result = "You Win!";
                aiLives--;
                isTie = false;
            }
            else
            {
                result = "You Lose!";
                playerLives--;
                isTie = false;
            }
        }

        resultText.text = result;
        UpdateHealthUI();  // Add this line
    }

    // private void UpdateScore()
    // {
    //     scoreText.text = $"Player: {playerLives} | AI: {aiLives}";
    // }

    private string GetAIMove()
    {
        string[] moves = { "Rock", "Paper", "Scissors" };
        return moves[Random.Range(0, moves.Length)];
    }

    private void EndGame()
    {

        if (udpReceive != null)
        {
            udpReceive.CloseUDP();
        }

        //resultText.text = playerLives > aiLives ? "You Win the Game!" : "AI Wins the Game!";
        string finalResult = playerLives > aiLives ? "You Win!" : "You Lost!";
        resultText.text = finalResult;

        PlayerPrefs.SetString("GameResult", finalResult);
        PlayerPrefs.Save();


        IsRoundActive = false;
        SceneManager.LoadScene("EndMenu");
    }

    private void UpdateHealthUI()
    {
        // Update Player Health
        playerHealth1.gameObject.SetActive(playerLives >= 1);
        playerHealth2.gameObject.SetActive(playerLives >= 2);
        playerHealth3.gameObject.SetActive(playerLives >= 3);

        // Update Enemy Health
        enemyHealth1.gameObject.SetActive(aiLives >= 1);
        enemyHealth2.gameObject.SetActive(aiLives >= 2);
        enemyHealth3.gameObject.SetActive(aiLives >= 3);
    }

        void OnDisable()
    {
        // Clean up UDP connection when scene changes
        if (udpReceive != null)
        {
            udpReceive.CloseUDP();
        }
    }
}