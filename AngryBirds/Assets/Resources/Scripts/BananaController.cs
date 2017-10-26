using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour {

    public Rigidbody2D myRB;
    public float forceX;
    public float forceY;
    public float torque;

	// Use this for initialization
	void Start () 
    {
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(torque);
	}
	
	
}
