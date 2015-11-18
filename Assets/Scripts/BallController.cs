using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    /// <summary>
    /// The variables used in the BallController Class.
    /// </summary>
    #region
    public GameObject SpawnArea;
    public Rigidbody rb;

    Vector3 Movement;
    static float posx = 0.0f;
    static float posy = 0.0f;
    static float posz = 0.0f;
    public float Speed;
    Vector3 pos = new Vector3(posx, posy, posz);

    static float rotx = 0.0f;
    static float roty = 0.0f;
    static float rotz = 0.0f;
    public float TurnSpeed;
    Vector3 rot = new Vector3(rotx, roty, rotz);

    int power;
    public int health;
    string tower = "Tower";
    public float PushBack;
    #endregion

    /// <summary>
    /// Unity's Start method. Initializes several key variables.
    /// </summary>
    void Start () {
        SpawnArea = GameObject.Find("SpawnArea");
        rb = GetComponent<Rigidbody>();
        power = 2;
	}
	
    /// <summary>
    /// Unity's update method.
    /// </summary>
	void Update () {
        run();
	}

    /// <summary>
    /// The service interface with the Update method.
    /// </summary>
    void run()
    {
        PlayerControl();
        CheckDestroyed();
    }

    /// <summary>
    /// This is how the bogger moves.
    /// </summary>
    void PlayerControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Movement = transform.forward * Speed * Time.deltaTime;
            rb.AddForce(Movement);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rot.y = rot.y + TurnSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rot.y = rot.y - TurnSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(rot);
    }

    /// <summary>
    /// This is what happens when a bogger enters an enemy tower.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tower))
        {
            other.gameObject.GetComponent<TowerBehavior>().ReduceHealth(power);
            Movement = transform.forward * -PushBack;
            SpawnArea.GetComponent<SpawnAreaController>().UpdateScore(power);
        }
    }

    /// <summary>
    /// This method is called whenever damage is to be dealt to the bogger.
    /// </summary>
    /// <param name="damage"></param>
    public void ReduceHealth(int damage)
    {
        health = health - damage;
    }

    /// <summary>
    /// This method determines if the bogger has been destroyed, and unparents the main camera before destroying the bogger.
    /// </summary>
    void CheckDestroyed()
    {
        if(health <= 0)
        {
            Transform camera = gameObject.transform.FindChild("Main Camera");
            camera.SetParent(null);
            Destroy(gameObject);
        }
    }
}
