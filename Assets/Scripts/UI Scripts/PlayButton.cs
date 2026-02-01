using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameManager gm;
    public void PlayButtonClick()
    {
        gm.LoadGameScene();
    }
}
