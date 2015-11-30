using UnityEngine;
using System.Collections;

public class BoltController : MonoBehaviour {

    /// <summary>
    /// The variables used in the BoltController class.
    /// </summary>
    #region
    public float Speed;

    string enemy = "Enemy";
    string wall = "Wall";
    int power;
    #endregion

    /// <summary>
    /// Unity's Start Method. Contains important setup.
    /// </summary>
    void Start () {
        power = 1;
	}
	
	/// <summary>
    /// Unity's Update method.
    /// </summary>
	void Update () {
        Run();
	}

    /// <summary>
    /// The service interface with Unity's update method.
    /// </summary>
    void Run()
    {
        move();
    }

    /// <summary>
    /// How the bolt moves forward.
    /// </summary>
    void move()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * Speed;
    }

    /// <summary>
    /// This is how the bolt knows what to do when it hits something.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(enemy))
        {
            other.GetComponent<EnemyBehavior>().ReduceHealth(power);
            Destroy(gameObject);
        }

        if (other.transform.CompareTag(wall))
        {
            Destroy(gameObject);
        }
    }
}
