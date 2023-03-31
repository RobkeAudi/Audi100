using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyScoreText;
    private int ScoreNum;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyScoreText.text = "Score : " + ScoreNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnted2D(Collider2D Coin)
    {
        if(Coin.tag == "Points")
        {
            ScoreNum += 1;
            Destroy(Coin.gameObject);
        }
    }
}
