using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public GameObject explosion;
    public Rigidbody2D myRB;

	// Use this for initialization
	void Start ()
    {
        //Invoke("Explode", explodeTime);
        myRB.AddForce(new Vector2(26.0f, -5.5f), ForceMode2D.Impulse);
        myRB.AddTorque(-30.0f);
    }
	
	void Explode()
    {
        //Instantiate(explosion, transform.position, explosion.transform.rotation);
        explosion.SetActive(true);
        Vector3 temp = explosion.transform.rotation.eulerAngles;
        temp.x = 0.0f;
        temp.y = 0.0f;
        temp.z = 0.0f;
        explosion.transform.rotation = Quaternion.Euler(temp);
        explosion.transform.SetParent(null);

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Explode();           
        }
    }
}
