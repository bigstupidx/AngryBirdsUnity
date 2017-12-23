using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject levelCompletePanel;
    public GameObject levelFailPanel;
    public GameObject playerUnlockPanel;
    public Image imgNewPlayer;
    public Image imgLoser;
    public Text levelScore;
    public Text txtScore;
    public Image imgPause;
    public Image star1;
    public Image star2;
    public Image star3;

    public GameObject scoreManager;

    public int level;
    public int gorillaNum;
    public int lowScore;
    public int averageScore;
    public int highScore;

    private int currentDeadGorillaNum;

	// Use this for initialization
	void Start ()
    {
        currentDeadGorillaNum = 0;
        GetComponent<SaveLoadSystem>().Load();

        QualitySettings.SetQualityLevel(SettingInfo.settingInfo.getQuality() - 1, true);

        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().prepare();

        GameObject pauseManager = GameObject.Find("PauseManager");
        pauseManager.GetComponent<PauseManager>().showSettingInfo();

        GameObject playersManager = GameObject.Find("PlayersManager");
        playersManager.GetComponent<PlayersManager>().prepare();
    }


    public void increaseDeadGorillaNum()
    {
        currentDeadGorillaNum++;
        //Debug.Log("Num : " + currentDeadGorillaNum);
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
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playWinSound();
        levelCompletePanel.SetActive(true);

        LevelInfo lv = LevelsInfo.levelsInfo.getElement(level.ToString());
        int lvScore = lv.getScore();
        int currentScore = scoreManager.GetComponent<ScoreManager>().getScore();
        if (currentScore > lvScore)
            lv.setScore(currentScore);

        int rank = getRank(scoreManager.GetComponent<ScoreManager>().getScore());
        int lvStar = lv.getStarNum();
        if(rank > lvStar)
            lv.setStarNum(rank);

        if (level < 60)
        {
            LevelInfo nextlv = LevelsInfo.levelsInfo.getElement((level + 1).ToString());
            if (nextlv != null)
                nextlv.setState("unlocked");
        }

        GetComponent<SaveLoadSystem>().Save();

        Invoke("showRank", 1.25f);
    }

    void showFailPanel()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playFailSound();
        levelScore.enabled = false;
        imgPause.enabled = false;
        showLoser();
        levelFailPanel.SetActive(true);
    }

    void showRank()
    {
        int rank = getRank(scoreManager.GetComponent<ScoreManager>().getScore());
        string state = "";
        for(int i=0;i<PlayersInfo.playersInfo.getList().Count;i++)
        {
            if (PlayersInfo.playersInfo.getList()[i].getUnlockLevel() == level)
                state = PlayersInfo.playersInfo.getList()[i].getState();
        }
        if (level%10 == 0 && state == "locked")
            Invoke("showNewPlayer", 2.5f);

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
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playStarSound();
        star1.GetComponent<Animator>().SetBool("isShining", true);
    }

    void showStar2()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playStarSound();
        star2.GetComponent<Animator>().SetBool("isShining", true);
    }

    void showStar3()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playStarSound();
        star3.GetComponent<Animator>().SetBool("isShining", true);
    }

    void unlockPlayer()
    {
       for(int i=0;i<PlayersInfo.playersInfo.getList().Count;i++)
       {
            PlayerInfo player = PlayersInfo.playersInfo.getList()[i];
            if (player.getState() == "locked" && player.getUnlockLevel() == level)
            {
                player.setState("unlocked");
                GameObject gameManager = GameObject.Find("GameManager");
                gameManager.GetComponent<SaveLoadSystem>().Save();
            }
       }
    }

    string getNewPlayer()
    {
        for (int i = 0; i < PlayersInfo.playersInfo.getList().Count; i++)
        {
            PlayerInfo player = PlayersInfo.playersInfo.getList()[i];
            if (player.getState() == "locked" && player.getUnlockLevel() == level)
            {
                return player.getName();
            }
        }

        return null;
    }

    void showNewPlayer()
    {
        string name = getNewPlayer();
        unlockPlayer();
        imgNewPlayer.sprite = Resources.Load<Sprite>("Graphic/UI/Players/" + name);
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playUnlockPlayerSFX();
        playerUnlockPanel.SetActive(true);
        
    }

    void showLoser()
    {
        for (int i = 0; i < PlayersInfo.playersInfo.getList().Count; i++)
        {
            PlayerInfo player = PlayersInfo.playersInfo.getList()[i];
            if (player.getState() == "unlocked" && player.getSelected())
            {
                imgLoser.sprite = Resources.Load<Sprite>("Graphic/UI/Losers/" + player.getName());
                return;
            }
        }
    }
}
