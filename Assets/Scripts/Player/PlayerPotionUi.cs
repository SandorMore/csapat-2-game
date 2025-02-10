using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerPotionUi : MonoBehaviour
{
    private Player player;
    private TMP_Text potion;    
    void Start()
    {
        player = GetComponentInParent<Player>();
        potion = GetComponentInChildren<TMP_Text>();
    }


    void Update()
    {
        potion.text = $"{player.healAmount}";

        if (player.healAmount == 0)
        {
            potion.text = "";
        }
    }
}
