using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject levelLoader;
    public GameObject playerSelectPanel;

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

    private int level;

    // Use this for initialization
    void Start ()
    {
        level = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnButtonPlayPressed(bool pressed)
    {
        if(pressed)
        {
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
            imgRate.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Pressed/btn Rate pressed");
            comingsoonPanel.SetActive(true);
        }
        else
        {

        }
    }

    public void OnButtonClosePressed(bool pressed)
    {
        if (pressed)
        {
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


    public void OnButtonLevelPressed(int levelIndex)
    {
        level = levelIndex;
        playerSelectPanel.SetActive(true);       
    }

    public void OnButtonOKPressed()
    {
        playerSelectPanel.SetActive(false);
        levelLoader.GetComponent<LevelLoader>().LoadLevel(level);
    }

    public void OnButtonClosePressed()
    {
        playerSelectPanel.SetActive(false);
    }
}
