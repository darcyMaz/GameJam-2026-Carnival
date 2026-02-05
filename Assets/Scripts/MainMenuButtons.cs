using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
    
