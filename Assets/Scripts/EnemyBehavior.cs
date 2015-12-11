using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyBoundary
{
    public float xMin, xMax, zMin, zMax, yMin, yMax;
}

public class EnemyBehavior : MonoBehaviour {

    public EnemyBoundary EnemyBoundary;
    public float Speed;
    private float AttackSpeed;
    private float TimeToAttack;
    public int Health;
    public int Power;
    private string slash = "SlashTower";
    private string sniper = "SniperTower";
    private string city = "City";

	// Use this for initialization
	void Start () {
        Health = 2;
        Power = 2;
        AttackSpeed = 0;
        TimeToAttack = 2;
	}
	
	// Update is called once per frame
	void Update () {
        run();
	}

    void run()
    {
        Movement();
        Clamp();
        DestroyedCheck();
    }

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

    void Forward()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * Speed; ;
    }

    void Stop()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void DestroyedCheck()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReduceHealth(int damage)
    {
        Health = Health - damage;
    }

    void Clamp()
    {
        GetComponent<Rigidbody>().position = new Vector3
        (
        Mathf.Clamp(GetComponent<Rigidbody>().position.x, EnemyBoundary.xMin, EnemyBoundary.xMax),
        Mathf.Clamp(GetComponent<Rigidbody>().position.y, EnemyBoundary.yMin, EnemyBoundary.yMax),
        Mathf.Clamp(GetComponent<Rigidbody>().position.z, EnemyBoundary.zMin, EnemyBoundary.zMax)
        );
    }

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

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == city)
        {
            other.GetComponent<CityController>().ReduceHealth();
            Destroy(gameObject);
        }
    }

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
