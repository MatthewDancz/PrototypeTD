using UnityEngine;
using System.Collections;

public class TowerBehavior : MonoBehaviour {

    /// <summary>
    /// This region contains most of the variables used in the TowerBehavior class.
    /// </summary>
    #region
    public GameObject Shot;
    public GameObject Hydra;
    static private int level;
    float maxx = 4;
    float minx = -4;
    float maxz = 10;
    float minz = -4;

    Vector3 rotation;

    public float TimeTillShot;
    float CoolDown;
    public int health;
    #endregion

    /// <summary>
    /// Unity's Start method. Inializes critical variables.
    /// </summary>
    void Start () {
        level = 1;
	    rotation.x = 0;
        rotation.y = 2.5f;
        rotation.z = 0;
        health = Random.Range(20, 40);
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
        TimedShot();
        Rotate();
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
        transform.Rotate(rotation);
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
            level++;
            RandomSpawn();
            RandomSpawn();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// This method spawns new towers in random locations about the play area.
    /// </summary>
    void RandomSpawn()
    {
            Vector3 randomSpawn = new Vector3(Random.Range(minx, maxx),1.0f,Random.Range(minz, maxz));
            Instantiate(Hydra, randomSpawn, Quaternion.identity);
    }
}
