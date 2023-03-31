using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggersScript : MonoBehaviour
{
    //garsams, kurie tik groja vieną kartą, pvz. finišo linija ar sistemos ar pan.

    //priskirti AudioSource prie objekto, kuriam scriptą šitą naudoji reikia!!!

    AudioSource source;
    Collider2D soundTrigger;
    bool hasBeenHit = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && hasBeenHit == false)
        {
            source.Play();
            hasBeenHit = true;
        }
    }
}
