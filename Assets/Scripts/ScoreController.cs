using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

    /// <summary>
    /// This region contains all of the variables used by the ScoreController script.
    /// </summary>
    #region Variables are CarrierPosition, correction, score, slash, sniper, SniperCost, and SlashCost.
    public GameObject CarrierPosition; //A GameObject corrisponding to the location the towers are to spawn, set in the Unity Editor

    Vector3 correction = new Vector3(0, 0.2f, 0); //The vector3 used to correct the tower spawn position.

    public static int score; //The score of the player.

    private string slash = "SlashTower"; //A string set to the value of the tag SlashTower.
    private string sniper = "SniperTower"; //A string set to the value of the tag SniperTower.

    public int SniperCost; //The cost associated with the sniper tower, set in the Unity Editor.
    public int SlashCost; //The cost associated with the slash tower, set in the Unity Editor.
    #endregion

    /// <summary>
    /// The Unity Start method, sets the initial score to 500.
    /// </summary>
    void Start ()
    {
        UpdateScore(500);
	}

    /// <summary>
    /// The UpdateScore method updates the score by an amount specified in the parameter.
    /// </summary>
    /// <param name="points"></param>
    public void UpdateScore(int points)
    {
        score = score + points;
    }

    /// <summary>
    /// The TellScore method reveals the current score, without providing access to the score variable.
    /// </summary>
    /// <returns></returns>
    public int TellScore()
    {
        return score;
    }

    /// <summary>
    /// This method spawns new towers at the players current position, and deducts the cost of the tower from the players score.
    /// </summary>
    /// <param name="hydra"></param>
    public void Spawn(GameObject hydra)
    {
        if (hydra.tag == slash && score >= SlashCost)
        {
            UpdateScore(-SlashCost);
            Instantiate(hydra, CarrierPosition.transform.position + correction, Quaternion.identity);
        }

        if (hydra.tag == sniper && score >= SniperCost)
        {
            UpdateScore(-SniperCost);
            Instantiate(hydra, CarrierPosition.transform.position + correction, Quaternion.identity);
        }
    }
}
