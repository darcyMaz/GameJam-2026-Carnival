using UnityEngine;

public class SafetyReport : MonoBehaviour
{
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string results = gm.GetInspectorString();
        string[] results_arr = results.Split("\n");

        Transform[] children_transform = GetComponentsInChildren<Transform>();

        // I know it's not efficient but it's 4 things with max 16 total searches chill.
        // Compares the given results with existing disabled gameobjects. If they are a match, enable them.
        foreach (Transform child in children_transform)
        {
            foreach (string result in results_arr)
            {
                if (result == child.gameObject.name)
                {
                    child.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }


}
