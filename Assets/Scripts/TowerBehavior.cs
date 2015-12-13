using UnityEngine;
using System.Collections;

public class TowerBehavior : MonoBehaviour {

    /// <summary>
    /// This region contains most of the variables used in the TowerBehavior class.
    /// </summary>
    #region Variables are Shot, SpawnLocation, slash, sniper, enemy, rotation, TimeTillShot, SpinSpeed, CoolDown, Health, Power, and Value.
    public GameObject Shot; //A GameObject to be instantiated by the sniper tower, set in the Unity Editor.

    private string slash = "SlashTower"; //A variable corresponding to the tag with value of SlashTower.
    private string sniper = "SniperTower"; //A variable corresponding to the tag with value of SniperTower.
    private string enemy = "Enemy"; //A variable corresponding to the tag with value of Enemy.

    Vector3 rotation; //A vector3 used to hold the rotational amount of the slash tower.

    public float TimeTillShot; //A variable holding the value of the time before the sniper tower can fire another shot, set in the Unity Editor.
    public float SpinSpeed; //A variable holding the multiplier for rotation, set in the Unity Editor.
    float CoolDown; //A variable used by sniper tower to determine when to fire the next shot.
    public int Health; //A variable containing the amount of health the tower has, set in the Unity Editor.
    public int Power; //The amount of damage the tower does on contact with the enemy, set in the Unity Editor.
    public int Value; //The cost of the tower, set in the Unity Editor.
    #endregion

    /// <summary>
    /// Unity's Start method. Inializes critical variables.
    /// </summary>
    void Start () {
        rotation.x = 0;
        rotation.y = 1f;
        rotation.z = 0;
        AssignHealthPower();
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
            Slash();
        }
        else if (transform.tag == sniper)
        {
            TimedShot();
        }
        DestroyedCheck();
    }

    /// <summary>
    /// This is how the sniper tower fires its bolt.
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
    /// This is how the slash tower rotates.
    /// </summary>
    void Rotate()
    {
        transform.Rotate(rotation * SpinSpeed);
    }

    /// <summary>
    /// The ReduceHealth method reduces the towers health by a specified amount provided by the parameter.
    /// </summary>
    /// <param name="damage"></param>
    public void ReduceHealth(int damage)
    {
        Health = Health - damage;
    }

    /// <summary>
    /// The DestroyedCheck method checks to see if the tower has been destroyed.
    /// </summary>
    void DestroyedCheck()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// The Slash method casts a ray looking for anything tagged as enemy.
    /// </summary>
    void Slash()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1f))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.green, 1f);
            if (hit.transform.tag == enemy)
            {
                Attack(hit);
            }
        }
    }

    /// <summary>
    /// Attack calls the hit objects EnemyBehavior script, reduce health method for an amount equal to the tower's power.
    /// </summary>
    /// <param name="hit"></param>
    void Attack(RaycastHit hit)
    {
        hit.collider.GetComponent<EnemyBehavior>().ReduceHealth(Power);
    }

    /// <summary>
    /// The AssignHealthPower is effectively a constructor method that gives each spawned tower the appropriate attributes.
    /// </summary>
    void AssignHealthPower()
    {
        if (transform.tag == sniper)
        {
            Health = 20;
            Power = 0;
        }
        else if (transform.tag == slash)
        {
            Health = 40;
            Power = 2;
        }
    }
}
