using UnityEngine;
using System.Collections;

public class CityController : MonoBehaviour {

    public int health = 100;
    private string enemy = "Enemy";

    public void ReduceHealth()
    {
        health = health - 1;
    }
}
