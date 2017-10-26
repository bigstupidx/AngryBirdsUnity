using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaBController : MonoBehaviour {

    public float health;
    public Animator myAnim;

    private float roarTime;
    private float roarDuration;

    private bool isRoaring;
    private bool isDead;

    void Start()
    {
        roarTime = Time.time + 2.0f;
        roarDuration = 1.1f;


        isRoaring = false;
        isDead = false;
    }

    void Update()
    {
        if(Time.time >= roarTime && isRoaring)
        {
            roarTime = Time.time + Random.Range(3.0f, 5.0f);
            isRoaring = false;
            myAnim.SetBool("isRoaring", false);
        }

       
        if(Time.time >= roarTime && !isRoaring)
        {
            isRoaring = true;
            myAnim.SetBool("isRoaring", true);
            roarTime = Time.time + roarDuration;
        }

    }


    void OnCollisionEnter2D(Collision2D otherColl)
    {
        if (otherColl.relativeVelocity.magnitude > health)
        {
            isDead = true;
            myAnim.SetBool("isDead", true);
            if(transform.childCount > 0)
                Destroy(transform.GetChild(0).gameObject);
            Invoke("makeDead", 5.0f);
        }
    }


    void makeDead()
    {
        Destroy(gameObject);
    }
}
