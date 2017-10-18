using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float health = 4.0f;

	void OnCollisionEnter2D(Collision2D otherColl)
    {
        if(otherColl.relativeVelocity.magnitude > health)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
