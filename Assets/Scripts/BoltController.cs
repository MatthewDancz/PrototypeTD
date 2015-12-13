using UnityEngine;
using System.Collections;

public class BoltController : MonoBehaviour {

    /// <summary>
    /// The variables used in the BoltController class.
    /// </summary>
    #region Variables are Speed, enemy, ground, and power.
    public float Speed; //Speed of the bolt in the game world. Set in the editor.

    string enemy = "Enemy"; //String representing the Enemy tag in the Editor.
    string ground = "Ground"; //String representing the ground tag in the Editor.
    int power; //Integer representing the damge this bolt does.
    #endregion

    /// <summary>
    /// Unity's Start Method. Contains important setup.
    /// Sets the power of the bolt to 1.
    /// </summary>
    void Start () {
        power = 1;
	}
	
	/// <summary>
    /// Unity's Update method. Activates the Run method.
    /// </summary>
	void Update () {
        Run();
	}

    /// <summary>
    /// The service interface with Unity's update method. Activates all other methods in the class.
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
    /// Compares the tag of the hit object's collider, and does stuff accordingly.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(enemy))
        {
            other.GetComponent<EnemyBehavior>().ReduceHealth(power);
            Destroy(gameObject);
        }

        if (other.transform.CompareTag(ground))
        {
            Destroy(gameObject);
        }
    }
}
