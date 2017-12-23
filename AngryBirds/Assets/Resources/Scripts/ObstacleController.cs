using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public Animator myAnim;
    public float health;
    //public string woodDust;
    public GameObject scorePS;
    public GameObject dustPS;
    public int type;

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
                dustPS.SetActive(true);
                dustPS.transform.SetParent(null);
                Vector3 temp = dustPS.transform.rotation.eulerAngles;
                temp.x = -90.0f;
                temp.y = 0.0f;
                temp.z = 0.0f;
                dustPS.transform.rotation = Quaternion.Euler(temp);
                dustPS.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                updateScore();
                playBreakSound();
            }
            isDead = true;           
            Invoke("makeDead", 1.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "explosion" || collision.tag == "saw")
        {
            myAnim.SetBool("isDead", true);
            if (!isDead)
            {               
                dustPS.SetActive(true);
                dustPS.transform.SetParent(null);
                Vector3 temp = dustPS.transform.rotation.eulerAngles;
                temp.x = -90.0f;
                temp.y = 0.0f;
                temp.z = 0.0f;
                dustPS.transform.rotation = Quaternion.Euler(temp);
                dustPS.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                updateScore();
                playBreakSound();
            }
            isDead = true;
            Invoke("makeDead", 1.0f);
        }
    }

    void updateScore()
    {
        GameObject scoreManager = GameObject.Find("ScoreManager");
        scoreManager.GetComponent<ScoreManager>().increaseScore(250);

        /*GameObject scorePrefab = (GameObject)Resources.Load("Prefabs/Effects/+250", typeof(GameObject));
        Instantiate(scorePrefab, transform.position, scorePrefab.transform.rotation);*/
        scorePS.transform.position = transform.position;
        scorePS.SetActive(true);
    }

    void makeDead()
    {
        gameObject.SetActive(false);
    }

    void playBreakSound()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playBreakSFX(type);
    }
}
