using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject gameManager;
    public GameObject playersManager;  
    public GameObject line1;
    public GameObject line2;
    public float smoothing;
    public float moveSpeed;

    private Transform target;
    private Vector3 offset;
    private Vector3 defaultPos;
    private bool move;
    private Vector3 Origin; 
    private Vector3 Diference;

    float lowY;
    float leftX;

    public float highY;
    public float rightX;
    //public float startPosX;

    private bool isStarted;

    // Use this for initialization
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;

        isStarted = false;
        move = false;
        defaultPos = new Vector3(0.0f, 0.0f, transform.position.z);


        //offset = transform.position - target.position;
        lowY = transform.position.y;
        leftX = transform.position.x;

        //transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);

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

                if(!target.GetComponent<BallController>().getFlying() && !target.GetComponent<BallController>().getDead())
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        if(mousePos.x >= 0.0f)
                            Origin = MousePos();
                    }
                    if (Input.GetMouseButton(0))
                    {
                        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        if (mousePos.x >= 0.0f)
                        {
                            Diference = MousePos() - transform.position;
                            transform.position = Origin - Diference;
                        }
                    }
                }

                if (move)
                {              
                    if (transform.position.x < 0.0f)
                        transform.position += Vector3.right * (moveSpeed*2.0f) * Time.deltaTime;
                    else
                        transform.position -= Vector3.right * (moveSpeed*2.0f) * Time.deltaTime;

                    if (transform.position.y < 0.0f)
                        transform.position += Vector3.up * (moveSpeed * 2.0f) * Time.deltaTime;
                    else
                        transform.position -= Vector3.up * (moveSpeed * 2.0f) * Time.deltaTime;


                    if (Mathf.Abs(transform.position.x) <= 0.2f && Mathf.Abs(transform.position.y) <= 1.77f) //y 1.75f
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
        offset = transform.position - target.position;
    }

    Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
