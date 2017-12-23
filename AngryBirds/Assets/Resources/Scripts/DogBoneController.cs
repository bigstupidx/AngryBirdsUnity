using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBoneController : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float forceX, forceY;
    public float torque;

	// Use this for initialization
	void Start () 
    {
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(torque);
        Destroy(gameObject, 5.0f);
	}
	
	
}
