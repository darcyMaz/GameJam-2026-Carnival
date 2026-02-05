using UnityEngine;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [SerializeField] private SceneLoader loader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        loader.LoadScene();
    }
}