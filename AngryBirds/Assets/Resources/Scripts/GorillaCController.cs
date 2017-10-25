using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaCController : MonoBehaviour {

    public float health;
    public Animator myAnim;

    private bool isDead;

    void Start()
    {
        isDead = false;
    }

    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D otherColl)
    {
        if (otherColl.relativeVelocity.magnitude > health)
        {
            isDead = true;
            myAnim.SetBool("isDead", true);
            Invoke("makeDead", 5.0f);
        }
    }


    void makeDead()
    {
        Destroy(gameObject);
    }
	
}
