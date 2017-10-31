using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public GameObject pausePanel;

    public Image imgPause;
    public Image imgMusic;
    public Image imgSFX;
    public Image imgResume;
    public Image imgRestart;
    public Image imgExit;

    private bool isMusicOn;
    private bool isSFXOn;

	// Use this for initialization
	void Start () 
    {
        isMusicOn = true;
        isSFXOn = true;
	}

    public void doPause(bool pause)
    {
        if (pause)
        {
            imgPause.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Pressed/btn Pause pressed");
            pausePanel.SetActive(true);
            Invoke("stopTime", 1.0f);
        }
        else
        {

        }
    }

    public void doResume(bool resume)
    {
        if (resume)
        {
            imgResume.color = new Color(1.0f, 1.0f, 1.0f, 0.55f);
        }
        else
        {
            Time.timeScale = 1.0f;
            imgPause.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn Pause");
            imgResume.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            pausePanel.GetComponent<Animator>().SetBool("isPausing", false);
            Invoke("HidePausePanel", 1.0f);
        }
    }

    void stopTime()
    {
        Time.timeScale = 0.0f;
    }

    void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }

	public void OnButtonMusicPressed(bool pressed)
    {
        if(pressed)
        {
            if(isMusicOn)
                imgMusic.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn music off");
            else
                imgMusic.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn music on");

            isMusicOn = !isMusicOn;
        }
        else
        {

        }
    }

    public void OnButtonSFXPressed(bool pressed)
    {
        if (pressed)
        {
            if (isSFXOn)
                imgSFX.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn sound effect off");
            else
                imgSFX.sprite = Resources.Load<Sprite>("Graphic/UI/Buttons/Normal/btn sound effect on");

            isSFXOn = !isSFXOn;
        }
        else
        {

        }
    }

    
}
