using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    float speed;
    float health;

	// Use this for initialization
	void Start () {
        speed = 8;
        health = 2;
	}
	
	// Update is called once per frame
	void Update () {
        run();
	}

    void run()
    {
        Forward();
        DestroyedCheck();
    }

    void Forward()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * speed; ;
    }

    void DestroyedCheck()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReduceHealth(int damage)
    {
        health = health - damage;
    }
}
