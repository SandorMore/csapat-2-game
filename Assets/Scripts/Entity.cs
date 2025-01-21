using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Collision Check")]

    public Transform attackCheck;
    public float attackCheckRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;


    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody2D>();
    }
    protected virtual void Update()
    {

    }
    public virtual bool isGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool isWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance, whatIsGround));
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + new Vector3(wallCheckDistance * facingDir, 0, 0));
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(attackCheck.position, attackCheckRadius);
    }
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void Damage()
    {
        Debug.Log(gameObject.name + "Was damged");
        
    }
    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
        {
            Flip();
        }
        else if (0 > _x && facingRight)
        {
            Flip();
        }
    }
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    public void ZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }

}
