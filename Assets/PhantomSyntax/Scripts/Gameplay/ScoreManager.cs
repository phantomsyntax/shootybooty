using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
                     private int playerScore = 000000;
                     public int PlayerScore { get { return playerScore;  } }

    public void UpdateScore(int incomingPoints)
    {
        playerScore += incomingPoints;
    }

    public void ResetScore() => playerScore = 000000;
}