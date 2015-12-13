using UnityEngine;
using System.Collections;

/// <summary>
/// The boudaries within which the enemy units can move, set in the Unity Editor.
/// </summary>
[System.Serializable]
public class EnemyBoundary
{
    public float xMin, xMax, zMin, zMax, yMin, yMax;
}

public class EnemyBehavior : MonoBehaviour {

    /// <summary>
    /// This region contains all the variables used by the EnemyBehavior class.
    /// </summary>
    #region Variables are EnemyBoundary, ScoreTally, Speed, AttackSpeed, TimeToAttack, Health, Power, Value, slash, sniper, and city.
    public EnemyBoundary EnemyBoundary; //An instance of the EnemyBoundary class containing our enemy movement restrictions.
    GameObject ScoreTally; //A gameObject with the ScoreController script, set in the Unity Editor.
    public float Speed; //A float set in the Unity editor, and used to change the speed of the enemy.
    private float AttackSpeed; //A variable used to set the enemies rate of attack.
    private float TimeToAttack; //A variable set in the Unity Editor to determine how often the enemy attacks.
    public int Health; //A variable that indicates the enemy units health
    public int Power; //A variable that indicates the amount of damage the enemy does.
    public int Value; //A variable indicating how much the unit is worth after being destroyed.
    private string slash = "SlashTower"; //A string representing the tag of a collided object.
    private string sniper = "SniperTower"; //A string representing the tag of a collided object.
    private string city = "City"; //A string representing the tag of a collided object.
    #endregion

    /// <summary>
    /// The Unity Start method sets severl variables and finds the gameObject named ScoreHolder in the Scene. 
    /// </summary>
    void Start () {
        ScoreTally = GameObject.Find("ScoreHolder");
        Health = 2;
        Power = 2;
        AttackSpeed = 0;
        TimeToAttack = 2;
        Value = 10;
	}
	
	/// <summary>
    /// The Unity Update method only execute the run method.
    /// </summary>
	void Update () {
        run();
	}

    /// <summary>
    /// The run method executes all of the methods in the EnemyBehavior class.
    /// </summary>
    void run()
    {
        Movement();
        Clamp();
        DestroyedCheck();
    }

    /// <summary>
    /// The Movement method controls when the enemy moves and doesn't.
    /// </summary>
    void Movement()
    {
        if (targetSighted() == true)
        {
            Stop();
        }
        else
        {
            Forward();
        }
        targetSighted();
    }

    /// <summary>
    /// The Forward method tells the attached gameObject to move forward at a constant speed.
    /// </summary>
    void Forward()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * Speed; ;
    }

    /// <summary>
    /// The Stop method tells the attached gameObject to stop moving forward.
    /// </summary>
    void Stop()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    /// <summary>
    /// The DestroyedCheck method determines if the enemies health is to low, and removes the gameObject if it is.
    /// </summary>
    void DestroyedCheck()
    {
        if (Health <= 0)
        {
            ScoreTally.GetComponent<ScoreController>().UpdateScore(Value);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// This method reduces the enemies health.
    /// </summary>
    /// <param name="damage"></param>
    public void ReduceHealth(int damage)
    {
        Health = Health - damage;
    }

    /// <summary>
    /// This method restricts the enemies movement to a specified boundary. Uses the EnemyBoundary class attributes.
    /// </summary>
    void Clamp()
    {
        GetComponent<Rigidbody>().position = new Vector3
        (
        Mathf.Clamp(GetComponent<Rigidbody>().position.x, EnemyBoundary.xMin, EnemyBoundary.xMax),
        Mathf.Clamp(GetComponent<Rigidbody>().position.y, EnemyBoundary.yMin, EnemyBoundary.yMax),
        Mathf.Clamp(GetComponent<Rigidbody>().position.z, EnemyBoundary.zMin, EnemyBoundary.zMax)
        );
    }

    /// <summary>
    /// The targetSighted method casts a ray in front of the enemy and checks if it hits a tower the player has placed.
    /// </summary>
    /// <returns></returns>
    bool targetSighted()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1f))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.green, 1f);
            if (hit.transform.tag == slash || hit.transform.tag == sniper)
            {
                if (AttackDelay() == false)
                {
                    hit.collider.GetComponent<TowerBehavior>().ReduceHealth(Power);
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// The OnTriggerEnterCommand executes only when the enemy passes the players towers and enters the hit box on the players city.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == city)
        {
            other.GetComponent<CityController>().ReduceHealth();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// The AttackDelay method delays how frequently the enemy attacks when engaging the players towers.
    /// </summary>
    /// <returns></returns>
    private bool AttackDelay()
    {
        if (AttackSpeed > 0)
        {
            AttackSpeed -= Time.deltaTime;
            return true;
        }
        else
        {
            AttackSpeed = TimeToAttack;
            return false;
        }
    }
}
