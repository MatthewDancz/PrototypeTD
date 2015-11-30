using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {

    public GameObject[] EnemyList;
    public Vector3 spawnValues;
    public int HazardCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;

    // Use this for initialization
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
            yield return new WaitForSeconds(WaveWait);
        }
    }

    void CreateSoldier()
    {
        Instantiate(EnemyList[0], transform.position, transform.rotation);
    }
}
