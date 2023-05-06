using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
        
    }



    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
