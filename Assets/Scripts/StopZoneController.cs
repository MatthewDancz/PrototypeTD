using UnityEngine;
using System.Collections;

public class StopZoneController : MonoBehaviour {

    string ground = "Ground";
    string Wall = "Wall";
    string DirectionField = "EnemyMovementField";
    
    /// <summary>
    /// Produces an area that triggers the StopMoving function on the CharacterTokenController script.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ground)
        {
            return;
        }

        if (other.gameObject.tag == Wall)
        {
            return;
        }

        if (other.gameObject.tag == DirectionField)
        {
            return;
        }

        if (other.GetComponent<CharacterTokenController>())
        {
            other.GetComponent<CharacterTokenController>().StopMoving();
            Destroy(gameObject);
        }
    }
}
