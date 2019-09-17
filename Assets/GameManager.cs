using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("BackToMenu", 1f);
        }
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
