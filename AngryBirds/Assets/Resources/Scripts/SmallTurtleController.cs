using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTurtleController : MonoBehaviour {

    public Rigidbody2D myRB;
    public Animator myAnim;
    public float forceX, forceY;

    private bool isDead;

	// Use this for initialization
	void Start ()
    {
        isDead = false;
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myAnim.SetBool("isJumping", true);
        //Destroy(gameObject, 4.0f);
	}

    void OnCollisionEnter2D(Collision2D otherColl)
    {       
        //myRB.freezeRotation = false;
        isDead = true;
        myAnim.SetBool("isDead", true);
        Destroy(gameObject, 4.0f);
    }
}
