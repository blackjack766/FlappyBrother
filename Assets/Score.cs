using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    static int score = 0;
    static int highscore = 0;
    
    static public void Addpoint() {
        score++;

        if (score > highscore) { 
            highscore = score;
        }
    }
    private void Start() {
        score = 0;
        highscore = PlayerPrefs.GetInt("highScore", 0);
 }


    private void OnDestroy() {
        PlayerPrefs.SetInt("highScore", highscore);
    }
 

    void Update () {
        GetComponent <GUIText>().text = "Score: " + score + "\nHigh Score:  " + highscore;
	}
}
