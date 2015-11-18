using UnityEngine;
using System.Collections;

public class SpawnAreaController : MonoBehaviour {
   
    /// <summary>
    /// Contains the variables used by the SpawnAreaController.
    /// </summary>
    #region
    public GameObject LittleBugger;
    public int LittleBuggerCost;
    static private int GameScore = 0;
    private string scoreText = "Score: " + GameScore.ToString();
    #endregion

    /// <summary>
    /// This method spawns a little bugger, if the players score is large enough for the cost of the bogger.
    /// </summary>
    public void CreateLittleBugger()
    {
        if (GameScore > LittleBuggerCost)
        {
            Instantiate(LittleBugger, transform.position, Quaternion.identity);
            GameScore = GameScore - LittleBuggerCost;
        }
    }

    /// <summary>
    /// This method updates the GameScore attribute.
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        GameScore = GameScore + score;
        scoreText = "Score: " + GameScore.ToString();
    }

    /// <summary>
    /// This Unity method creates a GUI that various components can be added too.
    /// Currently only adds a label displaying the player score.
    /// </summary>
    void OnGUI()
    {
        //GUI.Label(new Rect(20, 20, 100, 100), scoreText);
        GUILayout.Label(scoreText);
    }
}
