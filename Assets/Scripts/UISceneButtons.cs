using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneButtons : MonoBehaviour
{
    [Header("Scene names must match exactly (case-sensitive)")]
    [SerializeField] private string firstLevelSceneName = "Level1";
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    // PLAY button (loads your first level)
    public void Play()
    {
        SceneManager.LoadScene(firstLevelSceneName);
    }

    // RESTART button (reloads current scene)
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // MAIN MENU button
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // QUIT button (works in a build; in editor it does nothing)
    public void Quit()
    {
        Application.Quit();
    }

    // Optional: load by scene name directly (useful for many buttons)
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Optional: load by build index
    public void LoadSceneByIndex(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
