using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {

    public GameObject[] EnemyList;
    public Vector3 spawnValues;
    public int HazardCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;
    public float xValue;
    public float zValue;

    private Vector3 RandomPosition;

    void Start () {
        StartCoroutine(run());
	}

    IEnumerator run()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                CreateSoldier();
                yield return new WaitForSeconds(SpawnWait);
            }
            if (transform.tag == "StartSpawn")
            {
                CreateNewAntHole();
            }
            yield return new WaitForSeconds(WaveWait);
        }
    }

    void CreateSoldier()
    {
        Instantiate(EnemyList[0], transform.position, transform.rotation);
    }

    void CreateNewAntHole()
    {
        RandomPosition = new Vector3(Random.Range(transform.position.x - xValue, transform.position.x + xValue), 0f, Random.Range(transform.position.z - zValue, transform.position.z + zValue));
        Instantiate(EnemyList[1], RandomPosition, transform.rotation);
    }
}
