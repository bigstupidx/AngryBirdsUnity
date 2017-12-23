using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}
    
    void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * 6.0f;
    }
}
