using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaCController : MonoBehaviour {

    public float health;
    public Animator myAnim;
    public GameObject scorePS;

    private bool isDead;

    void Start()
    {
        isDead = false;
    }

    void OnCollisionEnter2D(Collision2D otherColl)
    {
        if (otherColl.relativeVelocity.magnitude > health)
        {
            if (!isDead)
            {
                updateScore();
                updateDeadNum();
                playDeadSFX();
            }
            isDead = true;
            myAnim.SetBool("isDead", true);
            Invoke("makeDead", 5.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "explosion" || collision.tag == "saw")
        {
            if (!isDead)
            {
                updateScore();
                updateDeadNum();
                playDeadSFX();
            }
            isDead = true;
            myAnim.SetBool("isDead", true);
            Invoke("makeDead", 5.0f);
        }
    }

    void updateScore()
    {
        GameObject scoreManager = GameObject.Find("ScoreManager");
        scoreManager.GetComponent<ScoreManager>().increaseScore(2000);

        /*GameObject scorePrefab = (GameObject)Resources.Load("Prefabs/Effects/+2000", typeof(GameObject));
        Instantiate(scorePrefab, transform.position, scorePrefab.transform.rotation);*/

        scorePS.SetActive(true);
    }

    void updateDeadNum()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManager>().increaseDeadGorillaNum();
    }

    void makeDead()
    {
        gameObject.SetActive(false);
    }

    void playDeadSFX()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playMoanSound();
    }
}
