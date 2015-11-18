using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

    /// <summary>
    /// Can be used to destroy an object, in a specific time frame, after spawning it.
    /// </summary>
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }
}
