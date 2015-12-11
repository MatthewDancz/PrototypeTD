using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasText : MonoBehaviour {

    public GameObject City;
    public Text txt;

    public float TimeToWait;

    private string level;
    
    string gameMessage = "";

    void Start()
    {
        level = "Scene02";
    }
	
	// Update is called once per frame
	void Update () {
        run();
	}

    void run()
    {
        CheckGameEnd();
    }

    void CheckGameEnd()
    {
        if (City.GetComponent<CityController>().Health <= 0)
        {
            gameMessage = "Game Over";
            txt.text = gameMessage;
            Delay();
            Application.LoadLevel(level);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(TimeToWait);
    }
}
