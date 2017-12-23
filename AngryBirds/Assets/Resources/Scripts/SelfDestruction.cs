using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour {

    public float aliveTime;

	// Use this for initialization
	void Start () 
    {
        Invoke("HideGameObject", aliveTime);
	}

    void HideGameObject()
    {
        gameObject.SetActive(false);
    }
	
	
}
