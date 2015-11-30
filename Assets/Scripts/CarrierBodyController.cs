﻿using UnityEngine;
using System.Collections;

public class CarrierBodyController : MonoBehaviour {

    public Transform Parent;
    public float Degree;
    Vector3 tilt;
	
	void Update () {
        run();
	}

    void run()
    {
        Tilt();
    }

    void Tilt()
    {
        if (Input.GetKey(KeyCode.W))
        {
            tilt = new Vector3(Parent.rotation.x + Degree, Parent.rotation.y, Parent.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            tilt = new Vector3(Parent.rotation.x - Degree, Parent.rotation.y, Parent.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }
        else
        {
            tilt = new Vector3(Parent.rotation.x, Parent.rotation.y, Parent.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }
    }
}