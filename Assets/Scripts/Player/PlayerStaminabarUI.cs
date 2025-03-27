using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminabarUI : MonoBehaviour
{
    private Slider slider;
    private Player player;
    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        player = GetComponentInParent<Player>();
    }
    private void Update()
    {
        UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {
        slider.maxValue = player.maxStamina;
        slider.value = player.currentStamina;
    }
}
