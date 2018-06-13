using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
//https://blog.csdn.net/u011484013/article/details/52182997

public class cubeMove : MonoBehaviour
{

    // 通过射线检测主角是否落在地面或者物体上    


    private Vector3 move = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // rigidbody.velocity = transform.forward * 8.0f;
        velocity = GetComponent<Rigidbody>().velocity;
        //velocity = rigidbody.velocity;
        transform.Translate(move * 0.8f);
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, 10, velocity.z);
        }

    }
}