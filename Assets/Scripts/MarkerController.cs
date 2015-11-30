using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class MarkerController : MonoBehaviour {

    public Boundary Boundary;
    public GameObject[] Tower;

    public float Speed;
    static float rotx = 0.0f;
    static float roty = 0.0f;
    static float rotz = 0.0f;

    public float TurnSpeed;
    Vector3 rot = new Vector3(rotx, roty, rotz);
    Vector3 towerCorrection;
    float zero = 0.0f;

    void Update()
    {
        PlayerControl();
    }

    void PlayerControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.forward * Speed * Time.deltaTime;
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

        GetComponent<Rigidbody>().position = new Vector3
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, Boundary.xMin, Boundary.xMax),
            0.2001f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, Boundary.zMin, Boundary.zMax)
            );
    }

    /// <summary>
    /// This method spawns new towers in random locations about the play area.
    /// </summary>
    public void Spawn(string name)
    {
        if (name == "Sniper")
        {
            towerCorrection = new Vector3(zero, .2f, zero);
            Instantiate(Tower[0], transform.position + towerCorrection, Quaternion.identity);
        }
        if (name == "Slash")
        {
            towerCorrection = new Vector3(zero, .2f, zero);
            Instantiate(Tower[1], transform.position + towerCorrection, Quaternion.identity);
        }
    }
}
