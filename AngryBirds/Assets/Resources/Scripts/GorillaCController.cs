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
            if (!isDead)
                updateScore();
            isDead = true;
            myAnim.SetBool("isDead", true);
            Invoke("makeDead", 5.0f);
        }
    }

    void updateScore()
    {
        GameObject scoreManager = GameObject.Find("ScoreManager");
        scoreManager.GetComponent<ScoreManager>().increaseScore(2000);

        GameObject scorePrefab = (GameObject)Resources.Load("Prefabs/Effects/+2000", typeof(GameObject));
        Instantiate(scorePrefab, transform.position, scorePrefab.transform.rotation);
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
	
}
