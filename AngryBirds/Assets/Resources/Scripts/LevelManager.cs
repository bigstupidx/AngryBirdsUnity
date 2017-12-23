using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject levelLoader;
    public GameObject failPanel;
    public GameObject winPanel;
    public GameObject playerSelectPanel;
    public GameObject playerUnlockPanel;

    public Image failImg;

    public Image imgPanda;
    public Image imgBunny;
    public Image imgDog;
    public Image imgHedgehog;
    public Image imgGecko;
    public Image imgDeer;
    public Image imgMouse;
    public Image imgCat;
    public Image imgTurtle;

    // Use this for initialization
    void Start ()
    {
		
	}
	

    public void OnButtonMenuPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playButtonSFX();
        failPanel.SetActive(false);
        winPanel.SetActive(false);
        levelLoader.GetComponent<LevelLoader>().LoadLevel(2);
    }

    public void OnButtonReplayPressed(int levelIndex)
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playButtonSFX();
        failPanel.SetActive(false);
        winPanel.SetActive(false);
        levelLoader.GetComponent<LevelLoader>().LoadLevel(levelIndex);
    }

    public void OnButtonNextPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playButtonSFX();
        //winPanel.SetActive(false);
        string strSelectedPlayer = "";
        resetPlayerUI();
        for (int i = 0; i < PlayersInfo.playersInfo.getList().Count; i++)
        {
            if (PlayersInfo.playersInfo.getList()[i].getSelected() && PlayersInfo.playersInfo.getList()[i].getState() == "unlocked")
            {
                strSelectedPlayer = PlayersInfo.playersInfo.getList()[i].getName();
                break;
            }
        }
        selectPlayer(strSelectedPlayer);
       
        playerSelectPanel.SetActive(true);
    }

    public void OnButtonClosePressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playButtonSFX();
        playerSelectPanel.SetActive(false);
    }

    public void OnButtonOKPressed(int level)
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playButtonSFX();
        playerSelectPanel.SetActive(false);
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<SaveLoadSystem>().Save();
        GameObject adInterstitial = GameObject.Find("AdInterstitial");
        adInterstitial.GetComponent<AdInterstitial>().show();
        levelLoader.GetComponent<LevelLoader>().LoadLevel(level);
    }

    public void OnButtonPlayerPressed(string strPlayer)
    {
        PlayerInfo player = PlayersInfo.playersInfo.getElement(strPlayer);
        if(player.getState() == "unlocked" && player.getSelected() == false)
        {
            resetPlayerUI();
            resetPlayerSelect();
            selectPlayer(strPlayer);
        }
    }

    public void OnButtonOKPressed()
    {
        playerUnlockPanel.SetActive(false);
        resetPlayerUI();
        string strSelectedPlayer="";
        for(int i=0;i< PlayersInfo.playersInfo.getList().Count;i++)
        {
            if(PlayersInfo.playersInfo.getList()[i].getSelected() && PlayersInfo.playersInfo.getList()[i].getState()=="unlocked")
            {
                strSelectedPlayer = PlayersInfo.playersInfo.getList()[i].getName();
                break;
            }
        }
        selectPlayer(strSelectedPlayer);

        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager.GetComponent<GameManager>().level < 60)
            playerSelectPanel.SetActive(true);
    }

    void resetPlayerUI()
    {
        for(int i=0;i<PlayersInfo.playersInfo.getList().Count;i++)
        {
            string name = PlayersInfo.playersInfo.getList()[i].getName();
            string state = PlayersInfo.playersInfo.getList()[i].getState();
            bool selected = PlayersInfo.playersInfo.getList()[i].getSelected();

            switch (name)
            {
                case "panda":
                    {
                        if (state == "unlocked")                                      
                            imgPanda.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgPanda.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
                case "bunny":
                    {
                        if (state == "unlocked")
                            imgBunny.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgBunny.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
                case "dog":
                    {
                        if (state == "unlocked")
                            imgDog.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgDog.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
                case "hedgehog":
                    {
                        if (state == "unlocked")
                            imgHedgehog.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgHedgehog.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
                case "gecko":
                    {
                        if (state == "unlocked")
                            imgGecko.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgGecko.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
                case "deer":
                    {
                        if (state == "unlocked")
                            imgDeer.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgDeer.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
                case "mouse":
                    {
                        if (state == "unlocked")
                            imgMouse.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgMouse.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
                case "cat":
                    {
                        if (state == "unlocked")
                            imgCat.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgCat.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
                case "turtle":
                    {
                        if (state == "unlocked")
                            imgTurtle.sprite = Resources.Load<Sprite>("Graphic/UI/players unlocked/" + name + " unlocked");
                        else if (state == "locked")
                            imgTurtle.sprite = Resources.Load<Sprite>("Graphic/UI/players locked/" + name + " locked");
                    }
                    break;
            }
        }
    }

    void resetPlayerSelect()
    {
        for (int i = 0; i < PlayersInfo.playersInfo.getList().Count; i++)
        {
            PlayersInfo.playersInfo.getList()[i].setSelected(false);
        }
    }

    void selectPlayer(string strPlayer)
    {
        PlayerInfo player = PlayersInfo.playersInfo.getElement(strPlayer);
        player.setSelected(true);

        switch(strPlayer)
        {
            case "panda":
                imgPanda.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
            case "bunny":
                imgBunny.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
            case "dog":
                imgDog.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
            case "hedgehog":
                imgHedgehog.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
            case "gecko":
                imgGecko.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
            case "deer":
                imgDeer.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
            case "mouse":
                imgMouse.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
            case "cat":
                imgCat.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
            case "turtle":
                imgTurtle.sprite = Resources.Load<Sprite>("Graphic/UI/players selected/" + strPlayer + " selected");
                break;
        }
    }
}
