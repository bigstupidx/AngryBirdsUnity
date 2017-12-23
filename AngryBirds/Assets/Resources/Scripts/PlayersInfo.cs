using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class PlayersInfo : MonoBehaviour {

    public static PlayersInfo playersInfo;
    List<PlayerInfo> playerInfo;

    void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/saveFile1.cd"))
            createList();
        playersInfo = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	void createList()
    {
        playerInfo = new List<PlayerInfo>();
        playerInfo.Add(new PlayerInfo("panda", "unlocked", 0, true));
        playerInfo.Add(new PlayerInfo("bunny", "locked", 10, false));
        playerInfo.Add(new PlayerInfo("dog", "locked", 20, false));
        playerInfo.Add(new PlayerInfo("hedgehog", "locked", 30, false));
        playerInfo.Add(new PlayerInfo("gecko", "locked", 40, false));
        playerInfo.Add(new PlayerInfo("deer", "locked", 50, false));
        playerInfo.Add(new PlayerInfo("mouse", "locked", 60, false));
        playerInfo.Add(new PlayerInfo("cat", "locked", 70, false));       
        playerInfo.Add(new PlayerInfo("turtle", "locked", 80, false));
    }

    public void setList(List<PlayerInfo> list)
    {
        playerInfo = list;
    }

    public List<PlayerInfo> getList()
    {
        return playerInfo;
    }

    public PlayerInfo getElement(string strName)
    {
        for (int i = 0; i < playerInfo.Count; i++)
        {
            if (playerInfo[i].getName() == strName)
            {
                return playerInfo[i];
            }
        }

        return null;
    }
}

[Serializable]
public class PlayerInfo
{
    private string name;
    private string state;
    private int unlockLevel;
    private bool isSelected;

    public PlayerInfo(string strName,string strState, int iUnlockLevel, bool selected)
    {
        name = strName;
        state = strState;
        unlockLevel = iUnlockLevel;
        isSelected = selected;
    }

    public void setName(string strName)
    {
        name = strName;
    }

    public void setState(string strState)
    {
        state = strState;
    }

    public void setUnlockLevel(int iUnlockLevel)
    {
        unlockLevel = iUnlockLevel;
    }

    public void setSelected(bool selected)
    {
        isSelected = selected;
    }


    public string getName()
    {
        return name;
    }

    public string getState()
    {
        return state;
    }

    public int getUnlockLevel()
    {
        return unlockLevel;
    }

    public bool getSelected()
    {
        return isSelected;
    }
}
