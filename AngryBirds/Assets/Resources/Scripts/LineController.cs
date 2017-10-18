using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {

    public Transform pos1;
    public Transform pos2;
    private LineRenderer line;

	// Use this for initialization
	void Start () 
    {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLine()
    {
        line.SetPosition(0, pos1.position);
        line.SetPosition(1, pos2.position);
    }

    public void setPos(Transform pos)
    {
        pos1 = pos;
    }
}
