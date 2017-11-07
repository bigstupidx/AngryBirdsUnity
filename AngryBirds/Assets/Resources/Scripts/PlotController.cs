using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour {

    public GameObject vsImage;

    private float changeImageTime;
    private int index;
    private bool set;

	// Use this for initialization
	void Start ()
    {
        changeImageTime = Time.time + 6.0f;
        index = 1;
        set = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Time.time >= changeImageTime && index < 7)
        {
            index++;
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphic/UI/Plot/" + index.ToString());
            changeImageTime = Time.time + 6.0f;
            if (index == 6 && !set)
            {
                Invoke("showVSImage", 6.0f);
                set = true;
            }
        }
	}

    void showVSImage()
    {
        vsImage.SetActive(true);
    }
}
