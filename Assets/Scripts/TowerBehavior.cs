using UnityEngine;
using System.Collections;

public class TowerBehavior : MonoBehaviour {

    /// <summary>
    /// This region contains most of the variables used in the TowerBehavior class.
    /// </summary>
    #region
    public GameObject Shot;
    public GameObject Hydra;
    public GameObject SpawnLocation;
    private string slash = "SlashTower";
    private string sniper = "SniperTower";

    Vector3 rotation;

    public float TimeTillShot;
    public float SpinSpeed;
    float CoolDown;
    public int health;
    #endregion

    /// <summary>
    /// Unity's Start method. Inializes critical variables.
    /// </summary>
    void Start () {
	    rotation.x = 0;
        rotation.y = 1f;
        rotation.z = 0;
	}
	
	/// <summary>
    /// Unity's Update Method.
    /// </summary>
	void Update () {
        Run();
	}

    /// <summary>
    /// The service interface with Unity's update method.
    /// </summary>
    void Run()
    {
        if (transform.tag == slash)
        {
            Rotate();
        }
        else if (transform.tag == sniper)
        {
            TimedShot();
        }
        DestroyedCheck();
    }

    /// <summary>
    /// This is how the tower fires its bolt.
    /// </summary>
    void TimedShot()
    {
        if (CoolDown > 0)
        {
            CoolDown -= Time.deltaTime;
        }
        else
        {
            Instantiate(Shot, transform.position, transform.rotation);
            CoolDown = TimeTillShot;
        }
    }

    /// <summary>
    /// This is how the tower rotates.
    /// </summary>
    void Rotate()
    {
        transform.Rotate(rotation * SpinSpeed);
    }

    /// <summary>
    /// This method is called whenever damage is dealt to the tower.
    /// </summary>
    /// <param name="damage"></param>
    public void ReduceHealth(int damage)
    {
        health = health - damage;
    }

    /// <summary>
    /// This method checks to see if the tower has been destroyed, updates the game level, and spawns two more towers.
    /// </summary>
    void DestroyedCheck()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// This method spawns new towers in random locations about the play area.
    /// </summary>
    public void Spawn()
    {
        Instantiate(Hydra, SpawnLocation.transform.position, Quaternion.identity);
    }
}
