using UnityEngine;
using System.Collections;

public class PropellerController : MonoBehaviour {

    Vector3 rotation;

	void Start () {
        rotation.x = 0;
        rotation.y = 2.5f;
        rotation.z = 0;
    }
	
	void Update () {
        run();
	}

    void run()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(rotation);
    }
}
