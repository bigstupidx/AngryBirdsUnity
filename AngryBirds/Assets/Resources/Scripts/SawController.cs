using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour {

    public Rigidbody2D myRB;

	// Use this for initialization
	void Start ()
    {
        myRB.AddForce(new Vector2(17.0f, -6.0f), ForceMode2D.Impulse);
    }

}
