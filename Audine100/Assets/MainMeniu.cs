using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeniu : MonoBehaviour
{

    public GameObject playerskin;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}