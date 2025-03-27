using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Player _player;
    float xInput;
    // Start is called before the first frame update
    void Start()
    {
        _player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.H))
        {
            _player.InputPress(_player.healAbility);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _player.InputPress(_player.attackAbility);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.InputPress(_player.dodgeAbility);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _player.InputPress(_player.jumpAbility);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _player.InputRelease(_player.jumpAbility);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {

        }
        if (Mathf.Abs(xInput) > 0f)
        {
            _player.MovementInput(xInput * 0.01f);
        }
    }
}
