using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMeniu : MonoBehaviour
{
    public void QuitGame()
    {
        // Quit the game
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenCustomize()
    {
        SceneManager.LoadScene(3);
    }
}