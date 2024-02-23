using UnityEngine.SceneManagement;
using UnityEngine;

public class Event : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
