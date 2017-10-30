using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBoneController : MonoBehaviour {

    public Rigidbody2D myRB;

	// Use this for initialization
	void Start () 
    {
        myRB.AddForce(new Vector2(14.0f, -5.0f), ForceMode2D.Impulse);
        myRB.AddTorque(-30.0f);
        Destroy(gameObject, 5.0f);
	}
	
	
}
