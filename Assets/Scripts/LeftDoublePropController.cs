using UnityEngine;
using System.Collections;

public class LeftDoublePropController : MonoBehaviour {

    public Transform Parent;
    private float degree;
    private Vector3 tilt;

    // Use this for initialization
    void Start()
    {
        degree = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        run();
    }

    void run()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            tilt = new Vector3(transform.rotation.x - degree, transform.rotation.y, transform.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }

        else if (Input.GetKey(KeyCode.E))
        {
            tilt = new Vector3(transform.rotation.x + degree, transform.rotation.y, transform.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }

        else
        {
            tilt = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }
    }
}
