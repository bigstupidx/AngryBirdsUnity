using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject levelCompletePanel;
    public GameObject levelFailPanel;
    public Text levelScore;
    public Text txtScore;
    public Image imgPause;
    public Image star1;
    public Image star2;
    public Image star3;

    public GameObject scoreManager;

    public int gorillaNum;
    public int lowScore;
    public int averageScore;
    public int highScore;

    private int currentDeadGorillaNum;

	// Use this for initialization
	void Start ()
    {
        currentDeadGorillaNum = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void increaseDeadGorillaNum()
    {
        currentDeadGorillaNum++;
        Debug.Log("Num : " + currentDeadGorillaNum);
        if (currentDeadGorillaNum == gorillaNum)
            Invoke("makeWin", 5.0f);
    }

    public int getCurrentGorrillaDeadNum()
    {
        return currentDeadGorillaNum;
    }

    public int getRemainGorillaNum()
    {
        return (gorillaNum - currentDeadGorillaNum);
    }

    public void makeLose()
    {
        Invoke("showFailPanel", 1.0f);
    }

    int getRank(int score)
    {
        if (score >= lowScore && score < averageScore)
            return 1;
        else if (score >= averageScore && score < highScore)
            return 2;
        else if (score >= highScore)
            return 3;
        return 1;
    }

    void makeWin()
    {
        txtScore.text = "Score : " + scoreManager.GetComponent<ScoreManager>().getScore();
        levelScore.enabled = false;
        imgPause.enabled = false;
        levelCompletePanel.SetActive(true);
        Invoke("showRank", 1.25f);
    }

    void showFailPanel()
    {
        levelScore.enabled = false;
        imgPause.enabled = false;
        levelFailPanel.SetActive(true);
    }

    void showRank()
    {
        int rank = getRank(scoreManager.GetComponent<ScoreManager>().getScore());

        if(rank == 1)
        {
            showStar1();
        }

        if(rank == 2)
        {
            showStar1();
            Invoke("showStar2", 0.5f);
        }

        if (rank == 3)
        {
            showStar1();
            Invoke("showStar2", 0.5f);
            Invoke("showStar3", 1.0f);
        }
    }


    void showStar1()
    {
        star1.GetComponent<Animator>().SetBool("isShining", true);
    }

    void showStar2()
    {
        star2.GetComponent<Animator>().SetBool("isShining", true);
    }

    void showStar3()
    {
        star3.GetComponent<Animator>().SetBool("isShining", true);
    }

}
