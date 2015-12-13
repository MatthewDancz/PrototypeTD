using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    /// <summary>
    /// This region contains all of the variables used in the MenuController script.
    /// </summary>
    #region Variables are level.
    private string level;
    #endregion

    /// <summary>
    /// The Unity Start method, calls the resume fuction.
    /// </summary>
    void Start()
    {
        Resume();
    }

    /// <summary>
    /// The start game method, sets level and loads the scene named level.
    /// </summary>
    public void StartGame()
    {
        level = "Scene01";
        Application.LoadLevel(level);
    }

    /// <summary>
    /// The ExitGame method, terminates the application.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// The resume method hides the gameObject MenuController is attached too.
    /// </summary>
    public void Resume()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// The ExitLevel method sets level to menu screne name, and then loads the scene with that name.
    /// </summary>
    public void ExitLevel()
    {
        level = "Scene02";
        Application.LoadLevel(level);
    }
}
