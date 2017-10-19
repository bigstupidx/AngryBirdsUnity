using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour {

    public Rigidbody2D myRB;

	// Use this for initialization
	void Start () 
    {
        myRB.AddForce(new Vector2(-6.0f, 3.0f), ForceMode2D.Impulse);
        myRB.AddTorque(30.0f);
	}
	
	
}
