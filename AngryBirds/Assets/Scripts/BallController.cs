using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private bool isPressed;
    public bool isFlying;
    private bool isReleased;
    private bool isAdjusted;
    private float flyTime;
    private GameObject camera;

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
        isPressed = false;
        isFlying = false;
        isReleased = false;
        isAdjusted = false;

        line1.SetActive(true);
        line2.SetActive(true);
        GetComponent<TrailRenderer>().enabled = false;

        camera = GameObject.Find("Main Camera");
    }


    

    void FixedUpdate()
    {
        

       

        /*if(isPressed)
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

       
        if (isFlying)
        {
            Debug.Log(camera.GetComponent<Camera>().orthographicSize);
            camera.GetComponent<Camera>().orthographicSize += 0.01f;
        
        }

        if(isReleased && Time.time >= flyTime && !isAdjusted)
        {
            //isFlying = true;
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
        }*/
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            isPressed = true;
            myRB.isKinematic = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            myRB.isKinematic = false;
            isFlying = true;
            release();
        }

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

        if (isFlying && camera.GetComponent<Camera>().orthographicSize <= 7.0f)
        {
            Debug.Log(camera.GetComponent<Camera>().orthographicSize);
            camera.GetComponent<Camera>().orthographicSize += 0.018f;       
        }

        if(isFlying)
        {
            myAnim.SetFloat("verticalSpeed", myRB.velocity.y);
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

            //this.enabled = false;
            isAdjusted = true;
        }
    
    }
  
  

	/*public void OnMouseDown()
    {
        isPressed = true;
        myRB.isKinematic = true;
    }

    public void OnMouseUp()
    {
        isPressed = false;
        myRB.isKinematic = false;

        
        isFlying = true;
        release();
        //StartCoroutine(Release());
    }*/

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
