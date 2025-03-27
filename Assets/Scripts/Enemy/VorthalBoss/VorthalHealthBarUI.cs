using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VorthalHealthBarUI : MonoBehaviour
{
    private Slider slider;
    private Vorthal vorthal;

    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        vorthal = GetComponentInParent<Vorthal>();
        
    }
    void Update()
    {
        UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {
        slider.maxValue = vorthal.maxHealth;
        slider.value = vorthal.currentHealth;

    }
}
