using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityController : MonoBehaviour {

    /// <summary>
    /// This region contains all the variables used in the CityController Script.
    /// </summary>
    #region Variables are slider and Health.
    public Slider slider; //The canvas slider set in the Unity Editor, used to display the health remaining on the city.
    public int Health = 20; //The number of times an enemy unit can enter the city before the game ends.
    #endregion

    /// <summary>
    /// The Unity Start method, sets the slider's maximum value and adjusts it to match the current health of the city.
    /// </summary>
    void Start()
    {
        slider.maxValue = Health;
        SetSliderToHealth();
    }

    /// <summary>
    /// This method reduces the city health by one.
    /// </summary>
    public void ReduceHealth()
    {
        Health = Health - 1;
        SetSliderToHealth();
    }

    /// <summary>
    /// This method sets the slider's value to the current health of the city.
    /// </summary>
    void SetSliderToHealth()
    {
        slider.value = Health;
    }
}
