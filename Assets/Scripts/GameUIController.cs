// public class GameUIController : MonoBehaviour
// {
//     [SerializeField]
//     private AILogic aiLogic;  // Reference to your existing AILogic component

//     public void OnPlayerMoveButton(int moveIndex)
//     {
//         AILogic.Move playerMove = (AILogic.Move)moveIndex;
//         AILogic.Move enemyMove = aiLogic.GetEnemyMove();
//         string result = aiLogic.DetermineWinner(playerMove);
//         // Update UI with result
//     }
// }