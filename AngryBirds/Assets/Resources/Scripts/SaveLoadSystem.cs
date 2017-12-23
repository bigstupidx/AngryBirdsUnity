using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/saveFile1.cd");

        SaveManager saver = new SaveManager();
        
        saver.listLevel = LevelsInfo.levelsInfo.getList();
        saver.listPlayer = PlayersInfo.playersInfo.getList();
        saver.isMusicOn = SettingInfo.settingInfo.getMusic();
        saver.isSFXOn = SettingInfo.settingInfo.getSFX();
        saver.quality = SettingInfo.settingInfo.getQuality();
        saver.isIntroSeen = SettingInfo.settingInfo.getIntroSeen();

        binary.Serialize(fStream, saver);
        fStream.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile1.cd"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/saveFile1.cd", FileMode.Open);

            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();

            LevelsInfo.levelsInfo.setList(saver.listLevel);
            PlayersInfo.playersInfo.setList(saver.listPlayer);
            SettingInfo.settingInfo.setMusic(saver.isMusicOn);
            SettingInfo.settingInfo.setSFX(saver.isSFXOn);
            SettingInfo.settingInfo.setQuality(saver.quality);
            SettingInfo.settingInfo.setIntroSeen(saver.isIntroSeen);
        }
    }

}

[Serializable]
class SaveManager
{
    public List<LevelInfo> listLevel;
    public List<PlayerInfo> listPlayer;
    public bool isMusicOn;
    public bool isSFXOn;
    public int quality;
    public bool isIntroSeen;
}
