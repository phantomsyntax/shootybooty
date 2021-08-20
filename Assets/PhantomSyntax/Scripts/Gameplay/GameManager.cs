using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("Gameplay Settings")]
                     public static int playerLives = 3;

    private void Awake()
    {
        GameManagerInstance();
    }

    private void GameManagerInstance()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void PlayerDestroyed()
    {
        if (playerLives >= 1)
        {
            playerLives--;
            GetComponent<SceneLoader>().ResetScene();
        }
        else
        {
            playerLives = 3;
            GetComponent<SceneLoader>().GameOver();
        }
    }
}