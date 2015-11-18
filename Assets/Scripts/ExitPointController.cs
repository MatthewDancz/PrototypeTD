using UnityEngine;
using System.Collections;

public class ExitPointController : MonoBehaviour {

    /// <summary>
    /// This is where the variables used by the ExitPointcontroller class.
    /// </summary>
    #region
    public GameObject[] Exits;
    string ground = "Ground";
    int RangeValue = 50;
    #endregion

    /// <summary>
    /// Unity's Start method. Contains important map generation details.
    /// </summary>
    void Start () {
        SpawnTile();
	}

    /// <summary>
    /// A method that shoots a ray from the exit spawn location to test if adjacent ground tiles exist.
    /// </summary>
    /// <returns>bool</returns>
    bool CheckAdjacentTile()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1f))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.green, 3f);
            if (hit.transform.tag == ground)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// A method that constrains ground tile spawns to a given x, z region.
    /// </summary>
    public void SpawnTile()
    {
        if (gameObject.transform.position.x < RangeValue && gameObject.transform.position.x > -RangeValue)
        {
            if (gameObject.transform.position.z < RangeValue && gameObject.transform.position.z > -RangeValue)
            {
                CheckSpawnLocation();
            }
        }
    }

    /// <summary>
    /// A method that spawns ground tiles at exit locations if none already exits in the space.
    /// </summary>
    public void CheckSpawnLocation()
    {
        if (CheckAdjacentTile() == false)
        {
            int index = Random.Range(0, Exits.Length - 1);

            GameObject obj = (GameObject)Instantiate(Exits[index], transform.position, gameObject.transform.rotation);
        }
    }
}
