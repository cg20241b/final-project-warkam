using UnityEngine;

public class AILogic : MonoBehaviour
{
    public enum Move
    {
        Rock,
        Paper,
        Scissors
    }

    private Move enemyMove;
    private bool isGameActive = true;

    // Generate random enemy move
    public Move GetEnemyMove()
    {
        if (!isGameActive) RestartGame();
        int randomMove = Random.Range(0, 3);
        enemyMove = (Move)randomMove;
        return enemyMove;
    }

    // Compare player move with enemy move and return result
    public string DetermineWinner(Move playerMove)
    {
        if (!isGameActive)
        {
            RestartGame();
            return "Game restarted! Make your move.";
        }

        if (!IsValidMove(playerMove))
        {
            isGameActive = false;
            return "Invalid Move! Game will restart.";
        }

        if (playerMove == enemyMove)
            return "Draw!";

        switch (playerMove)
        {
            case Move.Rock:
                return (enemyMove == Move.Scissors) ? "You Win!" : "Enemy Wins!";
            case Move.Paper:
                return (enemyMove == Move.Rock) ? "You Win!" : "Enemy Wins!";
            case Move.Scissors:
                return (enemyMove == Move.Paper) ? "You Win!" : "Enemy Wins!";
            default:
                isGameActive = false;
                return "Invalid Move! Game will restart.";
        }
    }

    private bool IsValidMove(Move move)
    {
        return move == Move.Rock || move == Move.Paper || move == Move.Scissors;
    }

    public void RestartGame()
    {
        isGameActive = true;
        enemyMove = GetEnemyMove();
    }
}