using UnityEngine;
using UnityEngine.SceneManagement;

// Nguyễn Như Cường - 20200076
public class StartFight : MonoBehaviour
{
    public void Fight()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
