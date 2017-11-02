using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public Rigidbody2D myRB;
    public float forceX, forceY, angle;

    // Use this for initialization
    void Start()
    {
        Explode();
    }

    // Update is called once per frame
    void Update()
    {
         GetComponent<SpriteRenderer>().material.color = Color.Lerp(GetComponent<SpriteRenderer>().material.color, new Color(1.0f, 0.0f, 0.0f, 1.0f), 1.5f * Time.deltaTime);
    }

    public void Explode()
    {
        //myRB.gravityScale = 1.0f;
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(angle);
    }
}
