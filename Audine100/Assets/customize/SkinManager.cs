using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    //public SpriteRenderer sr;
    //public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    //public GameObject playerskin;
    public Text Points;

    void Start()
    {
        //int score = PlayerPrefs.GetInt("Score", 0); // retrieve the score from PlayerPrefs (default value is 0)
        //Debug.Log(score);
        //if (score == 0)
        //{
        //    Points.text = "Points: 0";
        //}

        //else
        //{
        //    Points.text = "Points: " + score;
        //}
    }

    //public void NextOptionCar()
    //{
    //    selectedSkin = selectedSkin + 1;
    //    if(selectedSkin == skins.Count)
    //    {
    //        selectedSkin = 0;
    //    }
    //    sr.sprite = skins[selectedSkin];
       
    //}

    //public void BackOptionCar()
    //{
    //    selectedSkin = selectedSkin - 1;
    //    if (selectedSkin < 0)
    //    {
    //        selectedSkin = skins.Count - 1;
    //    }
    //    sr.sprite = skins[selectedSkin];
    //}

    public void PlayGame()
    {
        //PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/selected.prefab");
        SceneManager.LoadScene(1);
    }
    
}
