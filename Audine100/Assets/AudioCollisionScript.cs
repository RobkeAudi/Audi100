using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollisionScript : MonoBehaviour
{
    //garsams, kurie paleidžiami atsitrenkus į kažką, pvz. priešą ar pan.

    //priskirti AudioSource prie objekto, kuriam scriptą šitą naudoji reikia!!!

    AudioSource source;
    Collider2D collider;
    float previousTime = 0;
    bool hasBeenHit = false;
    void Awake()
    {
        source = GetComponent<AudioSource>();
        collider = GetComponent<Collider2D>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //float currentTime = Time.time;
        //if (currentTime - previousTime >= 1) // tikrinimas, ar praėjo x laiko prieš praeitą susidūrimą (nesukurti triukšmo su tuo pačiu garsu)
        //{
        //    source.Play();
        //    previousTime = currentTime;  
        //}

        if (collider.gameObject.tag == "Player")
        {
            source.Play();
           
        }
    }
}
