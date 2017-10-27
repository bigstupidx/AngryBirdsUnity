using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisileController : MonoBehaviour {

    public float angle;
    public float speed;
    public GameObject explosion;

	// Use this for initialization
	void Start () 
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = angle;
        transform.rotation = Quaternion.Euler(rotationVector);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}

    void Move()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(-1.0f*speed * Time.deltaTime, 0 , 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "Player")
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }

}
