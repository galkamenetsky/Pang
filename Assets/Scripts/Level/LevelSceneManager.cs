using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    private static LevelSceneManager instance;
    public static LevelSceneManager Instance
    {
        get
        {
            if (instance == null)
                instance = new LevelSceneManager();
            return instance;
        }
    }
  
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
    }
   
}
