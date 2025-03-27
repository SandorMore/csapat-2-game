using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAbility : PlayerAbility
{

    GroundMoveAbility groundMove;
    public float jumpStrength = 1f;
    public float jumpMaxHeight = 3f;
    public AnimationCurve jumpCurve;
    private float savedYAtJumpStart = -10000;
    private float cumulativeYDisplacement = 0f;
    public override bool StartAbility()
    {
        if (!base.StartAbility())
            return false;

        //groundMove.gravityEnabled--;
        savedYAtJumpStart = gameObject.transform.position.y;
        cumulativeYDisplacement = 0;

        groundMove.ApplyForce(new Vector2(0, 1f), 1f);
        EndAbility();

        return true;
    }

    private float getJumpCurvePosition()
    {
        return cumulativeYDisplacement / jumpMaxHeight;
    }
    public override bool EndAbility()
    {
        if (!base.EndAbility())
            return false;

        //groundMove.gravityEnabled++;

        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        groundMove = gameObject.GetComponent<GroundMoveAbility>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsRunning)
        {
            if (cumulativeYDisplacement > jumpMaxHeight)
            {
                EndAbility();
                return;
            }
            float deltaTime = 1f / 60f;
            float yDelta = jumpStrength * deltaTime * jumpCurve.Evaluate(getJumpCurvePosition());
            //groundMove.AddMovementInput(new Vector2(0, yDelta)); //TODO delta time
            cumulativeYDisplacement += yDelta;
        }
    }
}
