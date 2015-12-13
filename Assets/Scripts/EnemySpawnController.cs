using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {

    /// <summary>
    /// This region contains all of the variables used by the EnemySpawnController class.
    /// </summary>
    #region Variables are EnemyList, spawnValues, HazardCount, SpawnWait, StartWait, WaveWait, xValue, zValue, and RandomPosition.
    public GameObject[] EnemyList; //A list of spawnable enemies, set in the Unity Editor.
    public Vector3 spawnValues; //A list of spawnValues set in the Unity Editor.
    public int HazardCount; //A variable used to determine how many enemies spawn per hole, set in the Unity Editor.
    public float SpawnWait; //A variable holding the value of time the coroutine waits to spawn another enemy, set in the Unity Editor.
    public float StartWait; //A variable holding the value of time the coroutine waits to begin the first cycle, set in the Unity Editor.
    public float WaveWait; //A variable hodling the value of time the coroutine waits to begin the next wave, set in the Unity Editor.
    public float xValue; //A variable used to hold the distance appart on the x,y plane new enemy spawn holes can spawn, set in the Unity Editor.
    public float zValue; //A variable used to hold the distance appart on the z,y plane new enemy spawn holes can spawn, set in the Unity Editor.

    private Vector3 RandomPosition; //A vector3 used to hold the new random position of a spawned enemy spawn hole.
    #endregion

    /// <summary>
    /// The Unity Start method, starts the run coroutine.
    /// </summary>
    void Start () {
        StartCoroutine(run());
	}

    /// <summary>
    /// The run method is how the class executes its other methods.
    /// </summary>
    /// <returns></returns>
    IEnumerator run()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                CreateSoldier();
                SpawnWait = Random.Range(1, 3);
                yield return new WaitForSeconds(SpawnWait);
            }
            if (transform.tag == "StartSpawn")
            {
                CreateNewAntHole();
            }
            yield return new WaitForSeconds(WaveWait);
        }
    }

    /// <summary>
    /// The CreateSoldier method instantiates a new enemy prefab at the spawn holes location.
    /// </summary>
    void CreateSoldier()
    {
        Instantiate(EnemyList[0], transform.position, transform.rotation);
    }

    /// <summary>
    /// The CreateNewAntHole method Instantiates a new Enemy spawn hole in a random location constrained by the position of the first enemy spawn hole.
    /// </summary>
    void CreateNewAntHole()
    {
        RandomPosition = new Vector3(Random.Range(transform.position.x - xValue, transform.position.x + xValue), 0f, Random.Range(transform.position.z - zValue, transform.position.z + zValue));
        Instantiate(EnemyList[1], RandomPosition, transform.rotation);
    }
}
