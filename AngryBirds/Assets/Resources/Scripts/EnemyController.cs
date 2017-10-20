using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float health;
    public Animator myAnim;
    public GameObject weapon;
    public Transform attackPos;

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
        /*if(Time.time >= roarTime && isRoaring)
        {
            roarTime = Time.time + Random.Range(3.0f, 5.0f);
            isRoaring = false;
            myAnim.SetBool("isRoaring", false);
        }*/

        if(Time.time >= attackTime && isAttacking)
        {
            isAttacking = false;
            myAnim.SetBool("isAttacking", false);
        }

        /*if(Time.time >= roarTime && !isRoaring)
        {
            isRoaring = true;
            myAnim.SetBool("isRoaring", true);
            roarTime = Time.time + roarDuration;
        }*/


        if(Time.time >= attackTime && !isAttacking && canAttack && !isDead)
        {
            Debug.Log("attacking");
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
        Instantiate(weapon, attackPos.position, weapon.transform.rotation);
    }

	void OnCollisionEnter2D(Collision2D otherColl)
    {
        if(otherColl.relativeVelocity.magnitude > health)
        {
            myAnim.SetBool("isDead", true);
            Invoke("makeDead", 5.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "Player")
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

    void makeDead()
    {
        Destroy(gameObject);
    }


}
