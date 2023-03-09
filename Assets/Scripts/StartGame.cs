using UnityEngine;
using UnityEngine.SceneManagement;

// Nguyễn Như Cường - 20200076
public class StartGame : MonoBehaviour
{
    public void StartG()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
