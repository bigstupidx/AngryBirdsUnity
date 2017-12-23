using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour {

    public AudioSource myAS;

    public AudioClip btnSFX;
    public AudioClip slideBtnSFX;

    private bool isSFXOn;
    private bool isMusicOn;
    // Use this for initialization
    void Start ()
    {
        setSFX(SettingInfo.settingInfo.getSFX());
        setMusic(SettingInfo.settingInfo.getMusic());
        prepareMusic();
    }

    void prepareMusic()
    {
        if (isMusicOn)
            myAS.Play();
        else
            myAS.Stop();
    }

    public void setSFX(bool isOn)
    {
        isSFXOn = isOn;
    }

    public void setMusic(bool isOn)
    {

        if(isMusicOn && !isOn)
        {
            myAS.Stop();
        }

        if(!isMusicOn && isOn)
        {
            myAS.Play();
        }

        isMusicOn = isOn;
    }

    public void playButtonSFX()
    {
        if (isSFXOn)
        {
            myAS.PlayOneShot(btnSFX);
        }
    }

    public void playSlideButtonSFX()
    {
        if (isSFXOn)
        {
            myAS.PlayOneShot(slideBtnSFX);
        }
    }

}
