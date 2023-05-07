using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelect : MonoBehaviour
{
    public GameObject selected;
    public GameObject Player;

    private Sprite playersprite;

    // Start is called before the first frame update
    void Start()
    {
        playersprite = selected.GetComponent<SpriteRenderer>().sprite;

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }

}
