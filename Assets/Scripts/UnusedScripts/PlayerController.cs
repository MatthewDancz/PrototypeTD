using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    //This class is currently not being used.

    /// <summary>
    /// The variables used in the PlayerController Class.
    /// </summary>
    #region
    public Transform Player;
    string characterToken = "Player";
    #endregion

    /// <summary>
    /// Unity's update method.
    /// </summary>
    void Update () {
		run();
	}

    /// <summary>
    /// Service interface with the Unity Update function.
    /// </summary>
	void run()
	{
        MousePosition();
	}

    /// <summary>
    /// This method is difficult to describe.
    /// Sends a ray into the scene, and changes the parent of the object it is attached too.
    /// Needs refactoring.
    /// </summary>
    void MousePosition()
    {
        Plane GroundPlane = new Plane(Vector3.up, Vector3.forward);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float rayDistance = Mathf.Infinity;
        Vector3 mouse = Vector3.zero;
        Vector3 correction = Vector3.up;
        

        //Sends a ray to the invisible ground plane.
        
        if (GroundPlane.Raycast(ray, out rayDistance))
        {
            mouse = ray.GetPoint(rayDistance) + correction;
        }

        /*
        Casts a Ray and tests to see if that ray hit a player piece.
        Holds information about the hit objects transform in the Raycast hit holder variable.
        */
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.tag == characterToken)
            {
                Player = hit.transform;
                //CorrectView = new Vector3(45f, Player.transform.rotation.y, Player.transform.rotation.z);
                gameObject.transform.SetParent(Player);
                //gameObject.transform.rotation = Quaternion.Euler(CorrectView);
                gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 15, Player.transform.position.z);
            }
        }
    }
}
