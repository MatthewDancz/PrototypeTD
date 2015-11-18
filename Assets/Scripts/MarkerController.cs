using UnityEngine;
using System.Collections;

public class MarkerController : MonoBehaviour {

    static float posx = 0.0f;
    static float posy = 0.0f;
    static float posz = 0.0f;
    public float Speed;
    Vector3 pos = new Vector3(posx, posy, posz);

    static float rotx = 0.0f;
    static float roty = 0.0f;
    static float rotz = 0.0f;
    public float TurnSpeed;
    Vector3 rot = new Vector3(rotx, roty, rotz);

    void Update()
    {
        PlayerControl();
    }

    void PlayerControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.forward * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * Speed;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rot.y = rot.y + TurnSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            rot.y = rot.y - TurnSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(rot);
    }
}
