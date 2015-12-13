using UnityEngine;
using System.Collections;

public class DoublePropController : MonoBehaviour {

    /// <summary>
    /// This region contains all of the variables used in the DoublePropController class.
    /// </summary>
    #region Variables are Parent, degree, and tilt.
    public Transform Parent; //The parent object set in the Unity Editor.
    private float degree; //The degrees of rotation.
    private Vector3 tilt; //The vector used to tilt the props.
    #endregion

    /// <summary>
    /// The Unity Start method sets the value of degree to fifteen.
    /// </summary>
    void Start () {
        degree = 15f;
	}
	
	/// <summary>
    /// The Unity Update method, only executes the run method.
    /// </summary>
	void Update ()
    {
        run();
	}

    /// <summary>
    /// The run method executes all methods needed each cycle.
    /// </summary>
    void run()
    {
        Rotate();
    }

    /// <summary>
    /// The Rotate method checks the players input and adjusts the gameObjects local rotation as needed.
    /// </summary>
    void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            tilt = new Vector3(transform.rotation.x + degree, transform.rotation.y, transform.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }

        else if (Input.GetKey(KeyCode.E))
        {
            tilt = new Vector3(transform.rotation.x - degree, transform.rotation.y, transform.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }

        else
        {
            tilt = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            transform.localRotation = Quaternion.Euler(tilt);
        }
    }
}
