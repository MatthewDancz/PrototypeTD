using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    private string level;

	// Use this for initialization
	void Start () {
        level = "Scene01";
	}
	
    public void StartGame()
    {
        Application.LoadLevel(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        
    }
}
