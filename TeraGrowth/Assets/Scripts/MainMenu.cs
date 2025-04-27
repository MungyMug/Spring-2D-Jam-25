using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
