using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject levelLoader;
    public GameObject playerSelectPanel;
    public GameObject instructionPanel;
    public GameObject settingPanel;

    public GameObject levelsRange1;
    public GameObject levelsRange2;
    public GameObject levelsRange3;

    public GameObject panelInstruct1;
    public GameObject panelInstruct2;
    public GameObject panelInstruct3;
    public GameObject panelInstruct4;
    public GameObject panelInstruct5;

    public Image imgPlay;
    public Image imgGame;
    public Image imgRate;
    public Image imgSetting;
    public Image imgAboutus;

    public GameObject levelSelectPanel;
    public Image imgLeft;
    public Image imgRight;
    public Image imgClose;

    public GameObject comingsoonPanel;
    public Image imgOK;

    public GameObject imgLevel1;
    public GameObject imgLevel2;
    public GameObject imgLevel3;
    public GameObject imgLevel4;
    public GameObject imgLevel5;
    public GameObject imgLevel6;
    public GameObject imgLevel7;
    public GameObject imgLevel8;
    public GameObject imgLevel9;
    public GameObject imgLevel10;
    public GameObject imgLevel11;
    public GameObject imgLevel12;
    public GameObject imgLevel13;
    public GameObject imgLevel14;
    public GameObject imgLevel15;
    public GameObject imgLevel16;
    public GameObject imgLevel17;
    public GameObject imgLevel18;
    public GameObject imgLevel19;
    public GameObject imgLevel20;

    public GameObject imgLevel21;
    public GameObject imgLevel22;
    public GameObject imgLevel23;
    public GameObject imgLevel24;
    public GameObject imgLevel25;
    public GameObject imgLevel26;
    public GameObject imgLevel27;
    public GameObject imgLevel28;
    public GameObject imgLevel29;
    public GameObject imgLevel30;
    public GameObject imgLevel31;
    public GameObject imgLevel32;
    public GameObject imgLevel33;
    public GameObject imgLevel34;
    public GameObject imgLevel35;
    public GameObject imgLevel36;
    public GameObject imgLevel37;
    public GameObject imgLevel38;
    public GameObject imgLevel39;
    public GameObject imgLevel40;

    public GameObject imgLevel41;
    public GameObject imgLevel42;
    public GameObject imgLevel43;
    public GameObject imgLevel44;
    public GameObject imgLevel45;
    public GameObject imgLevel46;
    public GameObject imgLevel47;
    public GameObject imgLevel48;
    public GameObject imgLevel49;
    public GameObject imgLevel50;
    public GameObject imgLevel51;
    public GameObject imgLevel52;
    public GameObject imgLevel53;
    public GameObject imgLevel54;
    public GameObject imgLevel55;
    public GameObject imgLevel56;
    public GameObject imgLevel57;
    public GameObject imgLevel58;
    public GameObject imgLevel59;
    public GameObject imgLevel60;

    public Image imgLevelRange;

    public Image imgMusicOn;
    public Image imgMusicOff;
    public Image imgSFXOn;
    public Image imgSFXOff;
    public Image imgVeryLow;
    public Image imgLow;
    public Image imgMedium;
    public Image imgHigh;

    public Image imgPanda;
    public Image imgBunny;
    public Image imgDog;
    public Image imgHedgehog;
    public Image imgGecko;
    public Image imgDeer;
    public Image imgMouse;
    public Image imgCat;
    public Image imgTurtle;

    private int level;
    private int currentInstruction;
    private int currentlevelRange;

    // Use this for initialization
    void Start()
    {
        level = 1;
        currentInstruction = 1;
        currentlevelRange = 1;

        GetComponent<SaveLoadSystem>().Load();

        showLevelInfo();
        showSettingInfo();
        resetPlayerUI();
        string strSelectedPlayer = "";
        for (int i = 0; i < PlayersInfo.playersInfo.getList().Count; i++)
        {
            if (PlayersInfo.playersInfo.getList()[i].getSelected() && PlayersInfo.playersInfo.getList()[i].getState() == "unlocked")
            {
                strSelectedPlayer = PlayersInfo.playersInfo.getList()[i].getName();
                break;
            }
        }
        selectPlayer(strSelectedPlayer);
    }


    public void OnButtonPlayPressed(bool pressed)
    {
        if (pressed)
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
            imgPlay.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Pressed/btn Next pressed");
            levelSelectPanel.SetActive(true);
        }
        else
        {

        }
    }

    public void OnButtonGamePressed(bool pressed)
    {
        if (pressed)
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
            imgGame.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Pressed/btn Game pressed");
            comingsoonPanel.SetActive(true);
        }
        else
        {

        }
    }

    public void OnButtonRatePressed(bool pressed)
    {
        if (pressed)
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
            imgRate.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Pressed/btn Rate pressed");
            comingsoonPanel.SetActive(true);
        }
        else
        {

        }
    }

    public void OnButtonSettingPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
        settingPanel.SetActive(true);
    }

    public void OnButtonClosePressed(bool pressed)
    {
        if (pressed)
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
            imgClose.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Pressed/btn Close pressed");
        }
        else
        {
            imgPlay.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn Next");
            imgClose.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn Close");
            levelSelectPanel.GetComponent<Animator>().SetBool("isClosed", true);
            Invoke("hideLevelSelectPanel", 1.75f);
        }
    }

    public void OnButtonOKPressed(bool pressed)
    {
        if (pressed)
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
            imgOK.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
        else
        {
            imgGame.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn Game");
            imgRate.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn Rate");
            imgOK.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            comingsoonPanel.GetComponent<Animator>().SetBool("isClosed", true);
            Invoke("hideComingSoonPanel", 1.2f);
        }
    }

    void hideLevelSelectPanel()
    {
        levelSelectPanel.GetComponent<Animator>().SetBool("isClosed", false);
        levelSelectPanel.SetActive(false);
    }

    void hideComingSoonPanel()
    {
        comingsoonPanel.GetComponent<Animator>().SetBool("isClosed", false);
        comingsoonPanel.SetActive(false);
    }


    public void OnButtonLevelPressed(int levelName)
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
        LevelInfo lv = LevelsInfo.levelsInfo.getElement(levelName.ToString());
        string state = lv.getState();
        if (state == "unlocked")
        {
            level = lv.getIndex();
            playerSelectPanel.SetActive(true);
        }
    }

    public void OnButtonOKPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
        playerSelectPanel.SetActive(false);
        GameObject gameManager = GameObject.Find("GameManager");
        GetComponent<SaveLoadSystem>().Save();
        levelLoader.GetComponent<LevelLoader>().LoadLevel(level);
    }

    public void OnButtonClosePressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
        playerSelectPanel.SetActive(false);
        instructionPanel.SetActive(false);
        settingPanel.SetActive(false);
    }

    public void OnButtonHelpPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playButtonSFX();
        instructionPanel.SetActive(true);
    }

    public void OnButtonInstructionRightPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();
        currentInstruction++;
        if (currentInstruction > 5)
            currentInstruction = 1;

        HideAllInstructions();
        switch (currentInstruction)
        {
            case 1:
                panelInstruct1.SetActive(true);
                break;
            case 2:
                panelInstruct2.SetActive(true);
                break;
            case 3:
                panelInstruct3.SetActive(true);
                break;
            case 4:
                panelInstruct4.SetActive(true);
                break;
            case 5:
                panelInstruct5.SetActive(true);
                break;
        }
    }

    public void OnButtonInstructionLeftPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();
        currentInstruction--;
        if (currentInstruction < 1)
            currentInstruction = 5;

        HideAllInstructions();
        switch (currentInstruction)
        {
            case 1:
                panelInstruct1.SetActive(true);
                break;
            case 2:
                panelInstruct2.SetActive(true);
                break;
            case 3:
                panelInstruct3.SetActive(true);
                break;
            case 4:
                panelInstruct4.SetActive(true);
                break;
            case 5:
                panelInstruct5.SetActive(true);
                break;
        }
    }

    public void OnButtonRightPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();
        currentlevelRange++;
        if (currentlevelRange > 3)
            currentlevelRange = 1;
        imgLevelRange.sprite = Resources.Load<Sprite>("Graphic/UI/Elements/range" + currentlevelRange.ToString());

        HideAllLevels();
        switch (currentlevelRange)
        {
            case 1:
                levelsRange1.SetActive(true);
                break;
            case 2:
                levelsRange2.SetActive(true);
                break;
            case 3:
                levelsRange3.SetActive(true);
                break;
        }

    }

    public void OnButtonLeftPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();
        currentlevelRange--;
        if (currentlevelRange < 1)
            currentlevelRange = 3;
        imgLevelRange.sprite = Resources.Load<Sprite>("Graphic/UI/Elements/range" + currentlevelRange.ToString());

        HideAllLevels();
        switch (currentlevelRange)
        {
            case 1:
                levelsRange1.SetActive(true);
                break;
            case 2:
                levelsRange2.SetActive(true);
                break;
            case 3:
                levelsRange3.SetActive(true);
                break;
        }

    }

    void HideAllInstructions()
    {
        panelInstruct1.SetActive(false);
        panelInstruct2.SetActive(false);
        panelInstruct3.SetActive(false);
        panelInstruct4.SetActive(false);
        panelInstruct5.SetActive(false);
    }

    void HideAllLevels()
    {
        levelsRange1.SetActive(false);
        levelsRange2.SetActive(false);
        levelsRange3.SetActive(false);
    }

    void showLevelInfo()
    {
        for (int i = 1; i <= 60; i++)
        {
            LevelInfo lv = LevelsInfo.levelsInfo.getElement(i.ToString());
            string state = lv.getState();
            switch (i)
            {
                case 1:
                    {
                        if (state == "locked")
                        {
                            imgLevel1.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel1.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 2:
                    {
                        if (state == "locked")
                        {
                            imgLevel2.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel2.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 3:
                    {
                        if (state == "locked")
                        {
                            imgLevel3.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel3.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 4:
                    {
                        if (state == "locked")
                        {
                            imgLevel4.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel4.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel4.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel4.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 5:
                    {
                        if (state == "locked")
                        {
                            imgLevel5.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel5.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel5.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel5.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 6:
                    {
                        if (state == "locked")
                        {
                            imgLevel6.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel6.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel6.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel6.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 7:
                    {
                        if (state == "locked")
                        {
                            imgLevel7.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel7.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel7.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel7.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 8:
                    {
                        if (state == "locked")
                        {
                            imgLevel8.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel8.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel8.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel8.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 9:
                    {
                        if (state == "locked")
                        {
                            imgLevel9.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel9.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel9.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel9.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 10:
                    {
                        if (state == "locked")
                        {
                            imgLevel10.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel10.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel10.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel10.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 11:
                    {
                        if (state == "locked")
                        {
                            imgLevel11.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel11.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel11.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel11.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 12:
                    {
                        if (state == "locked")
                        {
                            imgLevel12.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel12.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel12.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel12.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 13:
                    {
                        if (state == "locked")
                        {
                            imgLevel13.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel13.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel13.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel13.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 14:
                    {
                        if (state == "locked")
                        {
                            imgLevel14.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel14.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel14.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel14.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 15:
                    {
                        if (state == "locked")
                        {
                            imgLevel15.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel15.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel15.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel15.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 16:
                    {
                        if (state == "locked")
                        {
                            imgLevel16.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel16.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel16.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel16.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 17:
                    {
                        if (state == "locked")
                        {
                            imgLevel17.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel17.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel17.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel17.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 18:
                    {
                        if (state == "locked")
                        {
                            imgLevel18.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel18.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel18.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel18.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 19:
                    {
                        if (state == "locked")
                        {
                            imgLevel19.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel19.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel19.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel19.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 20:
                    {
                        if (state == "locked")
                        {
                            imgLevel20.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel20.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel20.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel20.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 21:
                    {
                        if (state == "locked")
                        {
                            imgLevel21.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel21.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel21.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel21.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 22:
                    {
                        if (state == "locked")
                        {
                            imgLevel22.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel22.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel22.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel22.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 23:
                    {
                        if (state == "locked")
                        {
                            imgLevel23.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel23.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel23.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel23.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 24:
                    {
                        if (state == "locked")
                        {
                            imgLevel24.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel24.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel24.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel24.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 25:
                    {
                        if (state == "locked")
                        {
                            imgLevel25.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel25.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel25.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel25.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 26:
                    {
                        if (state == "locked")
                        {
                            imgLevel26.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel26.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel26.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel26.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 27:
                    {
                        if (state == "locked")
                        {
                            imgLevel27.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel27.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel27.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel27.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 28:
                    {
                        if (state == "locked")
                        {
                            imgLevel28.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel28.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel28.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel28.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 29:
                    {
                        if (state == "locked")
                        {
                            imgLevel29.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel29.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel29.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel29.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 30:
                    {
                        if (state == "locked")
                        {
                            imgLevel30.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel30.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel30.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel30.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 31:
                    {
                        if (state == "locked")
                        {
                            imgLevel31.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel31.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel31.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel31.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 32:
                    {
                        if (state == "locked")
                        {
                            imgLevel32.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel32.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel32.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel32.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 33:
                    {
                        if (state == "locked")
                        {
                            imgLevel33.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel33.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel33.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel33.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 34:
                    {
                        if (state == "locked")
                        {
                            imgLevel34.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel34.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel34.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel34.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 35:
                    {
                        if (state == "locked")
                        {
                            imgLevel35.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel35.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel35.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel35.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 36:
                    {
                        if (state == "locked")
                        {
                            imgLevel36.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel36.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel36.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel36.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 37:
                    {
                        if (state == "locked")
                        {
                            imgLevel37.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel37.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel37.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel37.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 38:
                    {
                        if (state == "locked")
                        {
                            imgLevel38.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel38.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel38.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel38.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 39:
                    {
                        if (state == "locked")
                        {
                            imgLevel39.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel39.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel39.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel39.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 40:
                    {
                        if (state == "locked")
                        {
                            imgLevel40.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel40.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel40.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel40.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 41:
                    {
                        if (state == "locked")
                        {
                            imgLevel41.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel41.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel41.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel41.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 42:
                    {
                        if (state == "locked")
                        {
                            imgLevel42.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel42.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel42.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel42.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 43:
                    {
                        if (state == "locked")
                        {
                            imgLevel43.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel43.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel43.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel43.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 44:
                    {
                        if (state == "locked")
                        {
                            imgLevel44.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel44.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel44.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel44.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 45:
                    {
                        if (state == "locked")
                        {
                            imgLevel45.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel45.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel45.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel45.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 46:
                    {
                        if (state == "locked")
                        {
                            imgLevel46.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel46.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel46.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel46.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 47:
                    {
                        if (state == "locked")
                        {
                            imgLevel47.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel47.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel47.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel47.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 48:
                    {
                        if (state == "locked")
                        {
                            imgLevel48.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel48.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel48.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel48.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 49:
                    {
                        if (state == "locked")
                        {
                            imgLevel49.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel49.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel49.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel49.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 50:
                    {
                        if (state == "locked")
                        {
                            imgLevel50.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel50.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel50.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel50.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 51:
                    {
                        if (state == "locked")
                        {
                            imgLevel51.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel51.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel51.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel51.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 52:
                    {
                        if (state == "locked")
                        {
                            imgLevel52.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel52.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel52.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel52.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 53:
                    {
                        if (state == "locked")
                        {
                            imgLevel53.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel53.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel53.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel53.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 54:
                    {
                        if (state == "locked")
                        {
                            imgLevel54.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel54.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel54.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel54.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 55:
                    {
                        if (state == "locked")
                        {
                            imgLevel55.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel55.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel55.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel55.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 56:
                    {
                        if (state == "locked")
                        {
                            imgLevel56.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel56.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel56.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel56.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 57:
                    {
                        if (state == "locked")
                        {
                            imgLevel57.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel57.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel57.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel57.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 58:
                    {
                        if (state == "locked")
                        {
                            imgLevel58.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel58.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel58.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel58.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 59:
                    {
                        if (state == "locked")
                        {
                            imgLevel59.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel59.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel59.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel59.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
                case 60:
                    {
                        if (state == "locked")
                        {
                            imgLevel60.transform.GetChild(0).gameObject.SetActive(false);
                            imgLevel60.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/Locked");
                        }
                        else if (state == "unlocked")
                        {
                            imgLevel60.transform.GetChild(0).gameObject.SetActive(true);
                            int iStarNum = lv.getStarNum();
                            imgLevel60.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphic/UI/Elements/" + iStarNum.ToString() + "Star");
                        }
                    }
                    break;
            }

        }
    }

    public void OnButtonMusicPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();

        bool isOn = SettingInfo.settingInfo.getMusic();
        isOn = !isOn;
        SettingInfo.settingInfo.setMusic(isOn);
        soundManager.GetComponent<MenuSoundManager>().setMusic(isOn);
        GetComponent<SaveLoadSystem>().Save();
        updateMusicUI();
    }

    void updateMusicUI()
    {
        bool isOn = SettingInfo.settingInfo.getMusic();
        if(isOn)
        {
            imgMusicOn.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
            imgMusicOff.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
        }
        else
        {
            imgMusicOn.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
            imgMusicOff.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
        }

    }

    public void OnButtonSFXPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();

        bool isOn = SettingInfo.settingInfo.getSFX();
        isOn = !isOn;
        SettingInfo.settingInfo.setSFX(isOn);
        soundManager.GetComponent<MenuSoundManager>().setSFX(isOn);
        GetComponent<SaveLoadSystem>().Save();
        updateSFXUI();
    }

    void updateSFXUI()
    {
        bool isOn = SettingInfo.settingInfo.getSFX();
        if (isOn)
        {
            imgSFXOn.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
            imgSFXOff.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
        }
        else
        {
            imgSFXOn.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
            imgSFXOff.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
        }
    }

    void resetQualityUI()
    {
        imgVeryLow.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
        imgLow.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
        imgMedium.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
        imgHigh.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
    }

    void updateGraphicQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality - 1,true);
    }

    public void OnButtonVeryLowPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();

        int quality = SettingInfo.settingInfo.getQuality();

        if(quality != 1)
        {
            resetQualityUI();
            quality = 1;
            SettingInfo.settingInfo.setQuality(quality);
            GetComponent<SaveLoadSystem>().Save();
            updateGraphicQuality(quality);
            imgVeryLow.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
        }
    }

    public void OnButtonLowPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();

        int quality = SettingInfo.settingInfo.getQuality();

        if (quality != 2)
        {
            resetQualityUI();
            quality = 2;
            SettingInfo.settingInfo.setQuality(quality);
            GetComponent<SaveLoadSystem>().Save();
            updateGraphicQuality(quality);
            imgLow.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
        }
    }

    public void OnButtonMediumPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();

        int quality = SettingInfo.settingInfo.getQuality();

        if (quality != 3)
        {
            resetQualityUI();
            quality = 3;
            SettingInfo.settingInfo.setQuality(quality);
            GetComponent<SaveLoadSystem>().Save();
            updateGraphicQuality(quality);
            imgMedium.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
        }
    }

    public void OnButtonHighPressed()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<MenuSoundManager>().playSlideButtonSFX();

        int quality = SettingInfo.settingInfo.getQuality();

        if (quality != 4)
        {
            resetQualityUI();
            quality = 4;
            SettingInfo.settingInfo.setQuality(quality);
            GetComponent<SaveLoadSystem>().Save();
            updateGraphicQuality(quality);
            imgHigh.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
        }
    }

    void showSettingInfo()
    {
        bool isMusicOn = SettingInfo.settingInfo.getMusic();
        if (isMusicOn)
        {
            imgMusicOn.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
            imgMusicOff.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
        }
        else
        {
            imgMusicOn.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
            imgMusicOff.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
        }


        bool isSFXOn = SettingInfo.settingInfo.getSFX();
        if (isSFXOn)
        {
            imgSFXOn.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
            imgSFXOff.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
        }
        else
        {
            imgSFXOn.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/off");
            imgSFXOff.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
        }


        resetQualityUI();
        int quality = SettingInfo.settingInfo.getQuality();
        switch(quality)
        {
            case 1:
                imgVeryLow.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
                break;
            case 2:
                imgLow.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
                break;
            case 3:
                imgMedium.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
                break;
            case 4:
                imgHigh.sprite = Resources.Load<Sprite>("Graphic/UI/Setting/on");
                break;
        }
    }

    public void OnButtonPlayerPressed(string strPlayer)
    {
        PlayerInfo player = PlayersInfo.playersInfo.getElement(strPlayer);
        if (player.getState() == "unlocked" && player.getSelected() == false)
        {
            resetPlayerUI();
            resetPlayerSelect();
            selectPlayer(strPlayer);
        }
    }

    void resetPlayerUI()
    {
        for (int i = 0; i < PlayersInfo.playersInfo.getList().Count; i++)
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

        switch (strPlayer)
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
