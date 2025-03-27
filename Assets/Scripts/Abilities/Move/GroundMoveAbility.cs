using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveAbility : Ability
{

    public int gravityEnabled = 1;
    public float gravityRate = 1f;
    Vector2 gravityDirection = new Vector2(0, -1f);
    private Animator anim;
    public float BaseSpeed = 100f;
    [SerializeField] protected Transform groundCheck;
    Vector2 CumulativeInput;
    public LayerMask groundLayer;
    public float groundCheckDistance = 1f;
    private BoxCollider2D collisionBox;
    public int probeCount = 10;

    private Vector2 currentMomentum = new Vector2(0, 0);

    public void AddMovementInput(Vector2 NewInput, bool resetYMomentum = false, bool resetXMomentum = false)
    {
        CumulativeInput += NewInput;
        if (resetYMomentum)
            currentMomentum.y = 0;
        if (resetXMomentum)
            currentMomentum.x = 0;
    }
    public void ApplyForce(Vector2 direction, float force, bool resetYMomentum = false, bool resetXMomentum = false)
    {
        currentMomentum += direction * force;
        if (resetYMomentum)
            currentMomentum.y = 0;
        if (resetXMomentum)
            currentMomentum.x = 0;
    }
    private Vector2 ClampInputByCollision(Vector2 Input)
    {
        Vector2 ClampedInput = Input;
        for (int i = -(probeCount / 2); i < (probeCount / 2); ++i)
        {
            Vector2 probeStart = groundCheck.position + new Vector3(collisionBox.size.x * (float)i * (1f / (float)probeCount), 0, 0);
            if (Input.y > 0)
                probeStart.y += collisionBox.size.y; //We are tracing upward
            RaycastHit2D CastResult = Physics2D.Raycast(probeStart, Input.y <= 0 ? Vector2.down : Vector2.up, groundCheckDistance, groundLayer);
            Debug.DrawRay(probeStart, new Vector3(0, Input.y, 0));
            if (CastResult)
            {
                ClampedInput.y = 0;
                break;
            }
        }

        float facing = Input.x / Mathf.Abs(Input.x);
        if (Mathf.Abs(Input.x) > 0)
        {
            for (int i = -(probeCount / 2) + 1; i < (probeCount / 2); ++i)
            {
                Vector3 pivot = collisionBox.transform.position + new Vector3(facing * collisionBox.size.x / 2, 0, 0);
                Vector3 probeStart = pivot + new Vector3(0, collisionBox.size.y * (float)i * (1f / (float)probeCount), 0);
                RaycastHit2D CastResult = Physics2D.Raycast(probeStart, new Vector2(facing, 0), groundCheckDistance, groundLayer);
                Debug.DrawRay(probeStart, new Vector3(facing, 0, 0));
                if (CastResult)
                {
                    ClampedInput.x = 0;
                    break;
                }
            }
        }

        return ClampedInput;
    }

    private void ApplyMovementInput()
    {
        currentMomentum = ClampInputByCollision(currentMomentum);
        CumulativeInput = ClampInputByCollision(CumulativeInput + currentMomentum);
        this.gameObject.transform.position += new Vector3(CumulativeInput.x, CumulativeInput.y, 0);

        //TODO trace between start and endpoints to avoid clipping
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        collisionBox = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityEnabled > 0)
        {
            float deltaTime = 1f / 60f;
            currentMomentum += gravityDirection * gravityRate * 0.0066f * deltaTime;
        }
        ApplyMovementInput();
        if (Mathf.Abs(CumulativeInput.x) >= 0.01f)
            anim.SetBool("Move", true);
        else
            anim.SetBool("Move", false);

        CumulativeInput = new Vector2(0, 0);
    }
}
