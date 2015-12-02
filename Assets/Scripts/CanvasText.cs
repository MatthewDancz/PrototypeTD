using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasText : MonoBehaviour {

    public GameObject City;
    public Text txt;
    
    string gameMessage = "";
	
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
        if (City.GetComponent<CityController>().health <= 0)
        {
            gameMessage = "Game Over";
            txt.text = gameMessage;
        }
    }
}
