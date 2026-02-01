using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    public GameManager gm;

    public void CreditsButtonClick()
    {
        gm.LoadCreditsScene();
    }

 
}
