using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class LevelsInfo : MonoBehaviour
{

    public static LevelsInfo levelsInfo;
    List<LevelInfo> levelInfo;

    void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/saveFile1.cd"))
            createList();
        levelsInfo = this;
    }

    void Start()
    {
        
    }

    void createList()
    {
        levelInfo = new List<LevelInfo>();
        levelInfo.Add(new LevelInfo("1", 3, "unlocked", 0, 0));
        levelInfo.Add(new LevelInfo("2", 4, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("3", 5, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("4", 6, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("5", 7, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("6", 8, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("7", 9, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("8", 10, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("9", 11, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("10", 12, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("11", 13, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("12", 14, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("13", 15, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("14", 16, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("15", 17, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("16", 18, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("17", 19, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("18", 20, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("19", 21, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("20", 22, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("21", 23, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("22", 24, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("23", 25, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("24", 26, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("25", 27, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("26", 28, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("27", 29, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("28", 30, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("29", 31, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("30", 32, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("31", 33, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("32", 34, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("33", 35, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("34", 36, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("35", 37, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("36", 38, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("37", 39, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("38", 40, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("39", 41, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("40", 42, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("41", 43, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("42", 44, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("43", 45, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("44", 46, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("45", 47, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("46", 48, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("47", 49, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("48", 50, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("49", 51, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("50", 52, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("51", 53, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("52", 54, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("53", 55, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("54", 56, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("55", 57, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("56", 58, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("57", 59, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("58", 60, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("59", 61, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("60", 62, "locked", 0, 0));


        levelInfo.Add(new LevelInfo("61", 63, "unlocked", 0, 0));
        levelInfo.Add(new LevelInfo("62", 64, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("63", 65, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("64", 66, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("65", 67, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("66", 68, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("67", 69, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("68", 70, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("69", 71, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("70", 72, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("71", 73, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("72", 74, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("73", 75, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("74", 76, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("75", 77, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("76", 78, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("77", 79, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("78", 80, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("79", 81, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("80", 82, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("81", 83, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("82", 84, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("83", 85, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("84", 86, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("85", 87, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("86", 88, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("87", 89, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("88", 90, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("89", 91, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("90", 92, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("91", 93, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("92", 94, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("93", 95, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("94", 96, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("95", 97, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("96", 98, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("97", 99, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("98", 100, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("99", 101, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("100", 102, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("101", 103, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("102", 104, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("103", 105, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("104", 106, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("105", 107, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("106", 108, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("107", 109, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("108", 110, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("109", 111, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("110", 112, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("111", 113, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("112", 114, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("113", 115, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("114", 116, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("115", 117, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("116", 118, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("117", 119, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("118", 120, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("119", 121, "locked", 0, 0));
        levelInfo.Add(new LevelInfo("120", 122, "locked", 0, 0));
    }

    public void setList(List<LevelInfo> list)
    {
        levelInfo = list;
    }

    public List<LevelInfo> getList()
    {
        return levelInfo;
    }

    public LevelInfo getElement(string strName)
    {
        for (int i = 0; i < levelInfo.Count; i++)
        {
            if (levelInfo[i].getName() == strName)
            {
                return levelInfo[i];
            }
        }

        return null;
    }
}

[Serializable]
public class LevelInfo
{
    private string name;
    private int index;
    private string state;
    private int score;
    private int starNum;

    public LevelInfo(string strName, int iIndex, string strState, int iScore, int iStarNum)
    {
        name = strName;
        index = iIndex;
        state = strState;
        score = iScore;
        starNum = iStarNum;
    }

    //set
    public void setName(string strName)
    {
        name = strName;
    }

    public void setIndex(int iIndex)
    {
        if (index >= 3)
            index = iIndex;
    }

    public void setState(string strState)
    {
        state = strState;
    }

    public void setScore(int iScore)
    {
        if(iScore > 0)
            score = iScore;
    }

    public void setStarNum(int iStarNum)
    {
        if(iStarNum >=1 && iStarNum <=3)
            starNum = iStarNum;
    }

    //get
    public string getName()
    {
        return name;
    }

    public int getIndex()
    {
        return index;
    }

    public string getState()
    {
        return state;
    }

    public int getScore()
    {
        return score;
    }

    public int getStarNum()
    {
        return starNum;
    }

}
