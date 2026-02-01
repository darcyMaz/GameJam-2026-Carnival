using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public GameManager manager;

    public void MainMenuButtonClick()
    {
        manager.LoadMainMenu();
    }
}
