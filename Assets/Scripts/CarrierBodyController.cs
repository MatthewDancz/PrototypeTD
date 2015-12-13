using UnityEngine;
using System.Collections;

public class CarrierBodyController : MonoBehaviour {

    /// <summary>
    /// This region contains all of the variables used in the CarrierBodyController script.
    /// </summary>
    #region Variables are Parent, Degree, and tilt.
    public Transform Parent; //The Parent object of the CarrierBodyController which is set in the Unity Editor.
    public float Degree; //A float variable set in the Unity editor, and used to angle the ships various components as the player moves about.
    Vector3 tilt; //A vector3 variable used to temporarily hold the angle of various ship components while the player moves about.
    #endregion

    /// <summary>
    /// The Unity Update function, only excutes the run method.
    /// </summary>
    void Update () {
        run();
	}

    /// <summary>
    /// The run method excutes all the other methods needed to execute the CarrierBodyController.
    /// </summary>
    void run()
    {
        Tilt();
        Bank();
    }

    /// <summary>
    /// The Tilt method checks to see the input the player is pressing, and tilt the components of the Carrier as needed.
    /// </summary>
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

    /// <summary>
    /// The Bank method checks to see the input the player is pressing, and rotate the components of the Carrier as needed.
    /// </summary>
    void Bank()
    {
        if (Input.GetKey(KeyCode.A))
        {
            tilt = new Vector3(Parent.rotation.x, Parent.rotation.y, Parent.rotation.z + Degree);
            transform.localRotation = Quaternion.Euler(tilt);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tilt = new Vector3(Parent.rotation.x, Parent.rotation.y, Parent.rotation.z - Degree);
            transform.localRotation = Quaternion.Euler(tilt);
        }
    }
}
