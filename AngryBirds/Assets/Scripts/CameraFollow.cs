using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing;
    public float moveSpeed;
    Vector3 offset;
    float lowY;
    float leftX;

    public float highY;
    public float rightX;

    private bool isStarted;

    // Use this for initialization
    void Start()
    {
        isStarted = false;

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!isStarted)
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
        }

        if (isStarted)
        {
            if (target)
            {
                if (!target.GetComponent<BallController>().getPressed())
                {
                    Vector3 targetCamPos = target.position + offset;
                    transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
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
}
