using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource myAS;


    public AudioClip beingShotSFX;
    public AudioClip jumpSFX;
    public AudioClip hitSFX;
    public AudioClip throwSFX;

    public AudioClip iceBreakSFX;
    public AudioClip woodBreakSFX;
    public AudioClip rockBreakSFX;

    public AudioClip moanSFX;
    public AudioClip gorillaThrowSFX;

    public AudioClip winSFX;
    public AudioClip starSFX;
    public AudioClip failSFX;
    public AudioClip btnSFX;
    public AudioClip slideBtnSFX;
    public AudioClip unlockPlayerSFX;

    private bool isSFXOn;
    private bool isMusicOn;

    // Use this for initialization
    void Start ()
    {
        
    }

    public void prepare()
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

    public bool getSFX()
    {
        return isSFXOn;
    }

    public void setMusic(bool isOn)
    {

        if (isMusicOn && !isOn)
        {
            myAS.Stop();
        }

        if (!isMusicOn && isOn)
        {
            myAS.Play();
        }

        isMusicOn = isOn;
    }

    public void playBeingShotSound()
    {
        if(isSFXOn)
            myAS.PlayOneShot(beingShotSFX);
    }

    public void playJumpSound()
    {
        if (isSFXOn)
            myAS.PlayOneShot(jumpSFX);
    }

    public void playHitSound()
    {
        if (isSFXOn)
            myAS.PlayOneShot(hitSFX);
    }

    public void playBreakSFX(int type)
    {
        if (isSFXOn)
        {
            if (type == 1)
                myAS.PlayOneShot(iceBreakSFX);
            else if (type == 2)
                myAS.PlayOneShot(woodBreakSFX);
            else if (type == 3)
                myAS.PlayOneShot(rockBreakSFX);
        }
    }

    public void playMoanSound()
    {
        if (isSFXOn)
            myAS.PlayOneShot(moanSFX);
    }

    public void playThrowSound()
    {
        if (isSFXOn)
            myAS.PlayOneShot(throwSFX);
    }

    public void playGorillaThrowSound()
    {
        if (isSFXOn)
            myAS.PlayOneShot(gorillaThrowSFX);
    }

    public void playWinSound()
    {
        if (isSFXOn)
        {
            myAS.Stop();
            myAS.PlayOneShot(winSFX);
        }
    }

    public void playStarSound()
    {
        if (isSFXOn)
        {
            myAS.PlayOneShot(starSFX);
        }
    }

    public void playFailSound()
    {
        if (isSFXOn)
        {
            myAS.Stop();
            myAS.PlayOneShot(failSFX);
        }
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

    public void playUnlockPlayerSFX()
    {
        if (isSFXOn)
        {
            myAS.PlayOneShot(unlockPlayerSFX);
        }
    }
}
