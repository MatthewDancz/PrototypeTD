using UnityEngine;
using System.Collections;

/// <summary>
/// The Boundary class contains all of the variables used to contain the player on the battlefield, set in the Unity Editor.
/// </summary>
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class MarkerController : MonoBehaviour {

    /// <summary>
    /// This region contains all of the variables used by the MarkerController class.
    /// </summary>
    #region Variables are Boundary, Tower, Speed, rotx, roty, rotz, TurnSpeed, rot, towerCorrection, and zero.
    public Boundary Boundary; //An instance of the boundary class, used to constrain the players motion to the battlefield, set in the Unity Editor.

    public float Speed; //A variable used to control the speed of the players movement, set in the Unity Editor.

    static float roty = 0.0f; //A variable set to zero, representing the y component of the vector3 rot.
    static float zero = 0.0f; //A variable set to zero.
    Vector3 rot = new Vector3(zero, roty, zero); //A vector3 composed of rotx, roty, and rotz.

    public float TurnSpeed; //A variable use to control the turning speed of the player, set in the Unity Editor.
    #endregion

    /// <summary>
    /// The Unity Update method, runs the PlayerControl method.
    /// </summary>
    void Update()
    {
        PlayerControl();
    }

    /// <summary>
    /// The PlayerControl method check the user input and responds by moving the player around a designated battlefield.
    /// </summary>
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

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * Speed * Time.deltaTime;
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
}
