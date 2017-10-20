using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public Animator myAnim;
    public float health;

	// Use this for initialization
	void Start () 
    {
		
	}

    void OnCollisionEnter2D(Collision2D otherColl)
    {
        if (otherColl.relativeVelocity.magnitude > health)
        {
            myAnim.SetBool("isDead", true);
            Invoke("makeDead", 1.0f);
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
