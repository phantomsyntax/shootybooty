using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private enum SceneList
    {
        BootUp,
        Title,
        Shop,
        Setup,
        Level01,
        Level02,
        Level03,
        GameOver
    }
    private SceneList sceneList;

    public void BeginGame()
    {
        SceneManager.LoadScene((int) SceneList.Setup);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        SceneManager.LoadScene((int) SceneList.GameOver);
    }
}