using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour {

    public GameObject levelLoader;
    private float loadTime;
    private bool set;

	// Use this for initialization
	void Start ()
    {
        loadTime = Time.time + 5.0f;
        set = false;
        levelLoader.GetComponent<SaveLoadSystem>().Load();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Time.time >= loadTime && !set)
        {
            levelLoader.GetComponent<SaveLoadSystem>().Save();
            if(SettingInfo.settingInfo.getIntroSeen())
                levelLoader.GetComponent<LevelLoader>().LoadLevel(2);
            else
                levelLoader.GetComponent<LevelLoader>().LoadLevel(1);
            set = true;
        }
	}
}
