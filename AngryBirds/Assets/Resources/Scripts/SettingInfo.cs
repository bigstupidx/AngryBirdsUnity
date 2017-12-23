using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class SettingInfo : MonoBehaviour {

    public static SettingInfo settingInfo;
    private bool isMusicOn;
    private bool isSFXOn;
    private int quality;
    private bool isIntroSeen;

    void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/saveFile1.cd"))
            createInfo();
        settingInfo = this;
    }

    void createInfo()
    {
        isMusicOn = true;
        isSFXOn = true;
        quality = 3;
        isIntroSeen = false;
    }

    public void setMusic(bool On)
    {
        isMusicOn = On;
    }

    public void setSFX(bool On)
    {
        isSFXOn = On;
    }

    public void setQuality(int level)
    {
        quality = level; 
    }

    public void setIntroSeen(bool seen)
    {
        isIntroSeen = seen;
    }

    public bool getMusic()
    {
        return isMusicOn;
    }

    public bool getSFX()
    {
        return isSFXOn;
    }

    public int getQuality()
    {
        return quality;
    }

    public bool getIntroSeen()
    {
        return isIntroSeen;
    }
}
