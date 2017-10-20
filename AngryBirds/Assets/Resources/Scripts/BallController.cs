using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private bool isPressed;
    private bool isFlying;
    private bool isReleased;
    private bool isAdjusted;
    private bool isDead;
    private bool movedSet;

    private float endAttackTime;
    private float flyTime;
    private GameObject camera;

    public Rigidbody2D myRB;
    public Animator myAnim;
    
    public float releaseTime = 0.15f;
    public float maxDragDistance = 2.0f;
    public GameObject feather;


    private Rigidbody2D hook;
    private GameObject line1;
    private GameObject line2;

    void Start()
    {
        isPressed = false;
        isFlying = false;
        isReleased = false;
        isAdjusted = false;
        isDead = false;
        movedSet = false;

        hook = GameObject.Find("Hook").GetComponent<Rigidbody2D>();
        GetComponent<SpringJoint2D>().connectedBody = hook;

        line1 = GameObject.Find("Line1");
        line2 = GameObject.Find("Line2");      

        line1.GetComponent<LineController>().setPos(transform.GetChild(0));
        line2.GetComponent<LineController>().setPos(transform.GetChild(0));

        line1.SetActive(true);
        line2.SetActive(true);

        GetComponent<TrailRenderer>().enabled = false;

        camera = GameObject.Find("Main Camera");
        camera.GetComponent<CameraFollow>().setTarget(transform);
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

        if(isPressed && !isFlying && !isDead)
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

        if (isFlying && camera.GetComponent<Camera>().orthographicSize <= 6.75f)
        {
            //Debug.Log(camera.GetComponent<Camera>().orthographicSize);
            camera.GetComponent<Camera>().orthographicSize += 0.02f;       
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

        if(isDead && !movedSet && Time.time >= endAttackTime)
        {
            camera.GetComponent<CameraFollow>().setMove();
            movedSet = true;
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
        line1.GetComponent<LineController>().setDefaultPos();
        line2.GetComponent<LineController>().setDefaultPos();

        line1.SetActive(false);
        line2.SetActive(false);

        myAnim.SetBool("isJumping", true);
        transform.GetChild(0).gameObject.SetActive(false);

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
        if (!isDead)
            Instantiate(feather, transform.position, feather.transform.rotation);
        myRB.freezeRotation = false;
        isDead = true;
        isFlying = false;
        myAnim.SetBool("isDead", true);

        endAttackTime = Time.time + 3.0f;      
    }


}
