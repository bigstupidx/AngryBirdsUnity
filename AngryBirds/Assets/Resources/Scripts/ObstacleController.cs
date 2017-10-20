using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public Animator myAnim;
    public float health;
    public bool isDead;

	// Use this for initialization
	void Start () 
    {
        isDead = false;
	}

    void OnCollisionEnter2D(Collision2D otherColl)
    {
        if (otherColl.relativeVelocity.magnitude > health)
        {
            myAnim.SetBool("isDead", true);
            if (!isDead)
            {
                GameObject dustPrefab = (GameObject)Resources.Load("Prefabs/Effects/wood dust PS", typeof(GameObject));
                Instantiate(dustPrefab, transform.position, dustPrefab.transform.rotation);
            }
            isDead = true;
            Invoke("makeDead", 1.0f);
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
