using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Ability moveAbility;
    public Ability jumpAbility;
    public Ability dodgeAbility;
    public Ability attackAbility;
    public Ability healAbility;

    public void InputPress(Ability abilityToStart)
    {
        abilityToStart.StartAbility();
    }
    public void InputRelease(Ability abilityToStart)
    {
        abilityToStart.InputRelease();
    }
    public void MovementInput(float xInput)
    {
        ( (GroundMoveAbility) moveAbility ).AddMovementInput(new Vector2(xInput, 0), false, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
