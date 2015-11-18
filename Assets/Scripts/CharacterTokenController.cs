using UnityEngine;
using System.Collections;

public class CharacterTokenController : MonoBehaviour {

    /// <summary>
    /// Not used after
    /// </summary>

    public GameObject Marker;
    public Transform RayCastObject;
    public float turnSpeed;
    public float Speed;
    bool characterMoving;

    /// <summary>
    /// Unity's Start method. Contains important setup information.
    /// </summary>
    void Start () {
        RayCastObject = gameObject.transform;
        characterMoving = false;
    }
	
    /// <summary>
    /// Rotate the player toward the direction it is moving.
    /// </summary>
    /// <param name="target"></param>
    public void RotatePlayer(Vector3 target)
    {
        if (characterMoving == false)
        {
            // Determine the target rotation. This is the rotation if transform looks at the target point.
            var targetRotation = Quaternion.LookRotation(target - gameObject.transform.position);

            // Smoothly rotate towards the target point.
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetRotation, turnSpeed);
        }
    }

    public void CreateMyMarker(Vector3 position)
    {
        Instantiate(Marker, position, Quaternion.identity);
        RotatePlayer(position);
    }

    public void StayAlert()
    {

    }

    public void UpdatePosition(Vector3 position)
    {
        characterMoving = true;
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * Speed;

    }

    public void StopMoving()
    {
        characterMoving = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public bool AreYouMoving()
    {
        return characterMoving;
    }

    public void MoveStopPoint(Vector3 Position)
    {
        gameObject.GetComponentInChildren<Transform>().position = Position;
    }

}
