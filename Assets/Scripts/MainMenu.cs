using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void Level1(int score)
    {
        Scene currentScene = SceneManager.GetActiveScene();  // Get active scene
        if (score > 1000 && currentScene.name == "_Scene_0")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Method to check and load Level 2
    public void Level2(int score)
    {
        Scene currentScene = SceneManager.GetActiveScene();  // Get active scene
        if (score > 2000 && currentScene.name == "_Scene_1")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Method to check and load Level 3
    public void Level3(int score)
    {
        Scene currentScene = SceneManager.GetActiveScene();  // Get active scene
        if (score > 3000 && currentScene.name == "_Scene_2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Corrected
        }
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

    

