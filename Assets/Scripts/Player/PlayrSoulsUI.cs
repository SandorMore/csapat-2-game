using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayrSoulsUI : MonoBehaviour
{
    private Player player;
    private TMP_Text souls;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        souls = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        souls.text = $"{player.souls}";

    }
}
