using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
