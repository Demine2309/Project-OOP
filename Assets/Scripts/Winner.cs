using UnityEngine;
using UnityEngine.SceneManagement;

// Nguyễn Như Cường - 20200076
public class Winner : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
}
