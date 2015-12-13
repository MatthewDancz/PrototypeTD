using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasText : MonoBehaviour {
    
    /// <summary>
    /// Region containing all the variables for the CanvasText class.
    /// </summary>
    #region Variables are City, ScoreHolder, Txt, ScoreTxt, TimeToWait, level, gameMessage, and score.
    public GameObject City; //A City GameObject set in the Unity Editor.
    GameObject ScoreHolder; //A GameObject holding the ScoreController Script. Set in the Unity Editor
    public Text Txt; //A Canvas Text field, used to display a Game Over Message.
    public Text ScoreTxt; //A Canvas Text field, used to display the players current score.

    public float TimeToWait; //A float variable set in the Unity Editor, telling the Script how long to wait until returning to the second scene, which is a title and menu screen.

    private string level; //A string for holding the name of the scene we want to switch to.
    
    string gameMessage = ""; //gameMessage is displayed in the Text Txt property of this class.

    private int score; //The players current game score.
    #endregion

    /// <summary>
    /// The Unity Start Method sets important variables and runs the run method one.
    /// </summary>
    void Start()
    {
        ScoreHolder = GameObject.Find("ScoreHolder");
        level = "Scene02";
        run();
    }

    /// <summary>
    /// The Unity Update method, only exicutes the run method each cycle.
    /// </summary>
    void Update()
    {
        run();
    }

    /// <summary>
    /// The run method of the CanvasText class. Checks to see if the game has ended, and updates the score if gameMessage does not equal Game Over.
    /// </summary>
    void run()
    {
        CheckGameEnd();
        if (gameMessage != "Game Over")
        {
            UpdateScore();
        }
    }

    /// <summary>
    /// This method checks to see if a game ending state has occurred, and once one has occurred starts the coroutine to change back to the title screen.
    /// </summary>
    void CheckGameEnd()
    {
        if (City.GetComponent<CityController>().Health <= 0)
        {
            gameMessage = "Game Over";
            Txt.text = gameMessage;
            StartCoroutine(DelayLevelLoad());
        }
    }

    /// <summary>
    /// This method waits a specific amount of time as specified by TimeToWait, and then loads the menu/Title Screen.
    /// </summary>
    /// <returns></returns>
    IEnumerator DelayLevelLoad()
    {
        yield return new WaitForSeconds(TimeToWait);
        Application.LoadLevel(level);
    }

    /// <summary>
    /// This method updates the score variable, and the ScoreTxt text so that the game score is always displayed correctly.
    /// </summary>
    void UpdateScore()
    {
        score = ScoreHolder.GetComponent<ScoreController>().TellScore();
        ScoreTxt.text = "Score: " + score;
    }
}
