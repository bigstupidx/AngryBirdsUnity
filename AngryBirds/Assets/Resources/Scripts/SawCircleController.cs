using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCircleController : MonoBehaviour {

    private bool collided;

    // Use this for initialization
    void Start()
    {
        collided = false;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("11");
        if (collision.gameObject.layer == 9 && !collided)
        {
            
            collided = true;
            if (transform.childCount > 0)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.transform.position = transform.position;
                Vector3 temp = transform.GetChild(0).transform.rotation.eulerAngles;
                temp.x = 0.0f;
                temp.y = 0.0f;
                temp.z = 0.0f;
                transform.GetChild(0).transform.rotation = Quaternion.Euler(temp);
                transform.GetChild(0).SetParent(null);
            }
        }
    }
}
