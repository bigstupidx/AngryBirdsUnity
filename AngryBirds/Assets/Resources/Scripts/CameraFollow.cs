using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject gameManager;
    public GameObject playersManager;
    public Transform target;
    public GameObject line1;
    public GameObject line2;
    public float smoothing;
    public float moveSpeed;
    private Vector3 offset;
    private Vector3 defaultPos;
    private bool move;

    float lowY;
    float leftX;

    public float highY;
    public float rightX;

    private bool isStarted;

    // Use this for initialization
    void Start()
    {
        isStarted = false;
        move = false;
        defaultPos = new Vector3(0.0f, 0.0f, transform.position.z);


        offset = transform.position - target.position;
        lowY = transform.position.y;
        leftX = transform.position.x;
        
    }

 

    // Update is called once per frame
    void FixedUpdate()
    {

        /*if(!isStarted)
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
            if(transform.position.x <= 0.0f)
            {
                transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
                offset = transform.position - target.position;
                lowY = transform.position.y;
                leftX = transform.position.x;
                isStarted = true;
            }
        }*/

        //if (isStarted)
        {
            if (target)
            {
                if (!target.GetComponent<BallController>().getPressed() && !move)
                {
                    Vector3 targetCamPos = target.position + offset;
                    transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
                }

                if (move)
                {
                    //transform.position = Vector3.Lerp(transform.position, defaultPos, 0.02f);                 

                    if (transform.position.x < 0.0f)
                        transform.position += Vector3.right * (moveSpeed*2.0f) * Time.deltaTime;
                    else
                        transform.position -= Vector3.right * (moveSpeed*2.0f) * Time.deltaTime;

                    if (transform.position.y < 0.0f)
                        transform.position += Vector3.up * (moveSpeed * 2.0f) * Time.deltaTime;
                    else
                        transform.position -= Vector3.up * (moveSpeed * 2.0f) * Time.deltaTime;

                    if (GetComponent<Camera>().orthographicSize >= 5.0f)
                    {
                        GetComponent<Camera>().orthographicSize -= 0.015f;
                    }

                    //Debug.Log(transform.position.x + " - " + transform.position.y);

                    if (Mathf.Abs(transform.position.x) <= 0.2f && Mathf.Abs(transform.position.y) <= 0.2f)
                    {                        
                        Destroy(target.gameObject);

                        if (playersManager.GetComponent<PlayersManager>().getRemainPlayersNum() == 0 && gameManager.GetComponent<GameManager>().getRemainGorillaNum() > 0)
                        {
                            gameManager.GetComponent<GameManager>().makeLose();
                        }

                        move = false;
                        
                        Invoke("respawnPlayer", 0.5f);
                    }
                }
            }



            if (transform.position.y < lowY)
                transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
            if (transform.position.y > highY)
                transform.position = new Vector3(transform.position.x, highY, transform.position.z);
            if (transform.position.x < leftX)
                transform.position = new Vector3(leftX, transform.position.y, transform.position.z);
            if (transform.position.x > rightX)
                transform.position = new Vector3(rightX, transform.position.y, transform.position.z);
        }
    }

    void respawnPlayer()
    {
        activeRopes();
        playersManager.GetComponent<PlayersManager>().getPlayerReady();
    }

    void activeRopes()
    {
        line1.SetActive(true);
        line2.SetActive(true);
    }

    public void setMove()
    {
        move = true;
    }

    public void setTarget(Transform tg)
    {
        target = tg;
    }
}
