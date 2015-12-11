using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityController : MonoBehaviour {

    public Slider slider;
    public int Health = 20;
    
    void Start()
    {
        slider.maxValue = Health;
        SetSliderToHealth();
    }

    public void ReduceHealth()
    {
        Health = Health - 1;
        SetSliderToHealth();
    }

    void SetSliderToHealth()
    {
        slider.value = Health;
    }
}
