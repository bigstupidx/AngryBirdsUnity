using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int currentLevelScore;

    public Text txtScore;

	// Use this for initialization
	void Start () 
    {
        currentLevelScore = 0;
	}
	
	public void increaseScore(int score)
    {
        currentLevelScore += score;
        txtScore.text = "Score : " + currentLevelScore.ToString();
    }


}
