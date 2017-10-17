using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private bool isPressed = false;
    private bool isFlying;
    private bool isReleased;
    private bool isAdjusted;
    private float flyTime;

    public Rigidbody2D myRB;
    public Animator myAnim;
    public Rigidbody2D hook;
    public float releaseTime = 0.15f;
    public float maxDragDistance = 2.0f;
    //public LineRenderer line;

    public GameObject line1;
    public GameObject line2;

    void Start()
    {
        isFlying = false;
        isReleased = false;
        isAdjusted = false;

        line1.SetActive(true);
        line2.SetActive(true);
        GetComponent<TrailRenderer>().enabled = false;
    }

    void Update()
    {
        if(isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector3.Distance(mousePos,hook.position) > maxDragDistance)
            {
                myRB.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }
            else
            {
                myRB.position = mousePos;
            }
            UpdateLine();
        }

      


        if(isReleased && Time.time >= flyTime && !isAdjusted)
        {
            isFlying = true;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = true;

            Vector2 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float forceX = hook.position.x - releasePos.x;
            float forceY = hook.position.y - releasePos.y;
            myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);

            GetComponent<TrailRenderer>().enabled = true;
            GetComponent<SpringJoint2D>().enabled = false;

            this.enabled = false;
            isAdjusted = true;
        }
    
    }
  


	public void OnMouseDown()
    {
        isPressed = true;
        myRB.isKinematic = true;
    }

    public void OnMouseUp()
    {
        isPressed = false;
        myRB.isKinematic = false;

        release();
        //StartCoroutine(Release());
    }

    void release()
    {
        //Vector2 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float forceX = hook.position.x - releasePos.x;
        //float forceY = hook.position.y - releasePos.y;

        line1.SetActive(false);
        line2.SetActive(false);
        myAnim.SetBool("isJumping", true);

        isReleased = true;
        flyTime = Time.time + releaseTime;
    }

    public IEnumerator Release()
    {
        Vector2 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float forceX = hook.position.x - releasePos.x;
        float forceY = hook.position.y - releasePos.y;

        line1.SetActive(false);
        line2.SetActive(false);
        myAnim.SetBool("isJumping", true);
        
        yield return new WaitForSeconds(releaseTime);

        //GetComponent<SpringJoint2D>().enabled = false;
        isFlying = true;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = true;

        
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        //myRB.AddTorque(15.0f);

        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<SpringJoint2D>().enabled = false;
        
        this.enabled = false;
        
    }

    void UpdateLine()
    {
        line1.GetComponent<LineController>().UpdateLine();
        line2.GetComponent<LineController>().UpdateLine();
    }

    public bool getPressed()
    {
        return isPressed;
    }

    void OnCollisionEnter2D(Collision2D otherColl)
    {
        myRB.freezeRotation = false;
        myAnim.SetBool("isDead", true);
    }


}
