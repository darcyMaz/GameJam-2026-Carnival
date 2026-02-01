using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameManager gm;

    public void ExitButtonPressed()
    {
        gm.ExitGame();
    }
}
