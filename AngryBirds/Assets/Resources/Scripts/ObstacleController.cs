using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public Animator myAnim;
    public float health;
    public string woodDust;
    private bool isDead;

	// Use this for initialization
	void Start () 
    {
        isDead = false;
	}

    void OnCollisionEnter2D(Collision2D otherColl)
    {
        if (otherColl.relativeVelocity.magnitude > health && otherColl.gameObject.tag != "banana")
        {
            myAnim.SetBool("isDead", true);
            if (!isDead)
            {
                GameObject dustPrefab = (GameObject)Resources.Load("Prefabs/Effects/"+woodDust, typeof(GameObject));
                Instantiate(dustPrefab, transform.position, dustPrefab.transform.rotation);
                updateScore();
            }
            isDead = true;           
            Invoke("makeDead", 1.0f);
        }
    }

    void updateScore()
    {
        GameObject scoreManager = GameObject.Find("ScoreManager");
        scoreManager.GetComponent<ScoreManager>().increaseScore(250);

        GameObject scorePrefab = (GameObject)Resources.Load("Prefabs/Effects/+250", typeof(GameObject));
        Instantiate(scorePrefab, transform.position, scorePrefab.transform.rotation);
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
