using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject levelLoader;
    public GameObject failPanel;
    public GameObject winPanel;
    public GameObject playerSelectPanel;

	// Use this for initialization
	void Start ()
    {
		
	}
	

    public void OnButtonMenuPressed()
    {

        failPanel.SetActive(false);
        winPanel.SetActive(false);
        levelLoader.GetComponent<LevelLoader>().LoadLevel(2);
    }

    public void OnButtonReplayPressed(int levelIndex)
    {
        failPanel.SetActive(false);
        winPanel.SetActive(false);
        levelLoader.GetComponent<LevelLoader>().LoadLevel(levelIndex);
    }

    public void OnButtonNextPressed()
    {
        winPanel.SetActive(false);
        playerSelectPanel.SetActive(true);
    }

    public void OnButtonClosePressed()
    {
        playerSelectPanel.SetActive(false);
    }

    public void OnButtonOKPressed(int level)
    {
        playerSelectPanel.SetActive(false);
        levelLoader.GetComponent<LevelLoader>().LoadLevel(level);
    }
}
