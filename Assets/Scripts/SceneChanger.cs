using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private List<string> scenes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scenes = new List<string>();
        scenes.Add("Main Menu");
        scenes.Add("Game");
        scenes.Add("Credits");
        scenes.Add("Death");
        scenes.Add("End");
    }

    public bool ChangeScene(string scene)
    {
        if (scenes.Contains(scene))
        {
            SceneManager.LoadScene(scene);
            return true;
        } 
        else 
        {  
            Debug.Log("There was a problem changing scenes. The scene to change to does not exist in the scene list."); 
            return false; 
        }
    }

}
