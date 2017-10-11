using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private bool isPressed = false;
    public Rigidbody2D myRB;
    public Rigidbody2D hook;
    public float releaseTime = 0.15f;
    public float maxDragDistance = 2.0f;
    //public LineRenderer line;

    public GameObject line1;
    public GameObject line2;

    void Start()
    {
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
        }
        UpdateLine();
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

        StartCoroutine(Release());
    }

    public IEnumerator Release()
    {
        Vector2 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float forceX = hook.position.x - releasePos.x;
        float forceY = hook.position.y - releasePos.y;

        line1.SetActive(false);
        line2.SetActive(false);
        yield return new WaitForSeconds(releaseTime);

        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<SpringJoint2D>().enabled = false;
        
        this.enabled = false;
        
    }

    void UpdateLine()
    {
        line1.GetComponent<LineController>().UpdateLine();
        line2.GetComponent<LineController>().UpdateLine();
    }

}
