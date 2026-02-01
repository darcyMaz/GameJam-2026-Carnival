using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    public GameManager gm;

    public void OnButtonClick()
    {
        //Debug.Log("ButtonPressed");
        gm.LoadMainMenu();
    }

 
}
