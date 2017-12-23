using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaAController : MonoBehaviour
{

    public float health;
    public Animator myAnim;
    public GameObject weapon;
    public Transform attackPos;
    public GameObject scorePS;

    private float roarTime;
    private float roarDuration;

    private float attackTime;
    private float attackDuration;

    private bool isAttacking;
    private bool isRoaring;
    private bool isDead;
    private bool canAttack;

    void Start()
    {
        roarTime = Time.time + 2.0f;
        roarDuration = 1.1f;

        attackTime = 0.0f;
        attackDuration = 1.0f;

        isAttacking = false;
        canAttack = false;
        isRoaring = false;
        isDead = false;
    }

    void Update()
    {
       
        if(Time.time >= attackTime && isAttacking)
        {
            isAttacking = false;
            myAnim.SetBool("isAttacking", false);
        }

       

        if(Time.time >= attackTime && !isAttacking && canAttack && !isDead)
        {
            isAttacking = true;
            myAnim.SetBool("isAttacking", true);
            attackTime = Time.time + attackDuration;
            canAttack = false;
            Attack();
        }

    }

    void Attack()
    {
        Invoke("Throw", 0.7f);
    }

    void Throw()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundManager>().playGorillaThrowSound();
        Instantiate(weapon, attackPos.position, weapon.transform.rotation);
    }

	void OnCollisionEnter2D(Collision2D otherColl)
    {
        if(otherColl.relativeVelocity.magnitude > health)
        {
            if (!isDead)
            {
                updateScore();
                updateDeadNum();
                playDeadSFX();
            }
            isDead = true;
            myAnim.SetBool("isDead", true);
            if (transform.childCount > 0)
                transform.GetChild(0).gameObject.SetActive(false);
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
            if (transform.childCount > 0)
                transform.GetChild(0).gameObject.SetActive(false);
            Invoke("makeDead", 5.0f);
        }

        if (collision.tag == "Player")
        {
            canAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D otherColl)
    {
        if (otherColl.tag == "Player")
        {
            canAttack = false;
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
