using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingPlayerController : MonoBehaviour {

    public Rigidbody2D myRB;
    public Animator myAnim;
    public float forceX;
    public float forceY;
    public Transform des;

    private GameObject pos;
    private GameObject playersManager;
    private bool isReady;
    private bool isJumping;

	// Use this for initialization
	void Start () 
    {
        playersManager = GameObject.Find("PlayersManager");
        transform.SetParent(playersManager.transform);
        pos = GameObject.Find("Waiting Players Pos");

        isReady = false;
        isJumping = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isReady)
        {
            myAnim.SetFloat("verticalSpeed", myRB.velocity.y);
            if (transform.position.x < (pos.transform.position.x - 0.015f))
            {
                myAnim.SetBool("isRunning", true);
                Move();
            }
            else
            {
                if (!isJumping)
                {
                    isJumping = true;
                    Jump();
                }
            }
        }
	}

    void Jump()
    {
        myAnim.SetBool("isJumping", true);
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D otherColl)
    {
        if(otherColl.gameObject.tag == "bow")
        {
            playersManager.GetComponent<PlayersManager>().createPlayer();
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.position += Vector3.right * 2.0f * Time.deltaTime;
    }

    public void setReady()
    {
        isReady = true;
    }
}
