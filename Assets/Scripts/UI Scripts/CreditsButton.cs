using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{

    private void OnMouseDown()
    {
        // Switch scene to main menu
        SceneManager.LoadScene("Main Menu");
    }
}
