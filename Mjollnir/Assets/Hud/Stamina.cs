using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Stamina : MonoBehaviour
{
    static public Slider slider;
    float currentStamina = 3f;
    float maxStamina = 1000f;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentStamina / maxStamina;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReplenishStamina();
        }
    }

    public void ReplenishStamina()
    {
        currentStamina += 5;
    }
}
