using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private Player1Inputs pi;
    private PlayerController1 pc;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private TrailRenderer tr;
    private SpriteRenderer sr;
    private Animator anim;
    
    private bool canDash = true;
    private bool dash;
    private bool falling;
    private Vector2 movement;
    private LayerMask ground;
    private float jumpHeight;
    private float speed;
    private float dashStrength;
    private float dashTime;
    private float originalGravityScale;

    // Start is called before the first frame update
    private void Start()
    {
        pc = GetComponent<PlayerController1>();
        rb = pc.rb;
        coll = pc.coll;
        tr = pc.tr;
        sr = pc.sr;
        anim = pc.anim;
        ground = pc.ground;
        jumpHeight = pc.jumpHeight;
        speed = pc.speed;
        dashStrength = pc.dashStrength;
        dashTime = pc.dashTime;

        //Inputs
        pi = pc.pi;
        InitializeInputs();
    }

    private void InitializeInputs()
    {
        pi.PlayerMovement.Dash.started += context =>
        {
            if (canDash && movement != Vector2.zero) dash = true;
        };
    }

    public void SubUpdate()
    {
        movement = pi.PlayerMovement.Move.ReadValue<Vector2>();

        //dashing
        if (IsGrounded()) canDash = true;

        //update animation
        UpdateAnimations();
    }

    //physics (cursed jumps)
    public void SubFixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed * Time.deltaTime, movement.y > .1f && IsGrounded() ? movement.y * jumpHeight * Time.deltaTime : rb.velocity.y);
        if (dash) StartDashing();
    }

    //grounding mechanics (cursed)
    private bool IsGrounded()
    {
        Bounds bounds = coll.bounds;
        return Physics2D.CapsuleCast(bounds.center, bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, .1f, ground);
    }

    //update animations (also cursed)
    private void UpdateAnimations()
    {
        switch (movement.x)
        {
            case > .1f:
                anim.SetBool("facingLeft", false);
                anim.SetBool("isMoving", true);
                transform.GetChild(0).localScale = Vector3.right;
                break;
            case < -.1f:
                anim.SetBool("facingLeft", true);
                anim.SetBool("isMoving", true);
                transform.GetChild(0).localScale = Vector3.left;
                break;
            default:
                anim.SetBool("isMoving", false);
                break;
        }
    }

    //dashing functions (cursed)
    private void StartDashing()
    {
        dash = false;
        Vector2 direction = pi.PlayerMovement.Move.ReadValue<Vector2>().normalized;
        canDash = false;
        Color tmp = sr.color;
        tmp.a = 0.5f;
        tr.emitting = true;
        coll.enabled = false;
        originalGravityScale = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = direction * new Vector2(speed * dashStrength * Time.deltaTime, jumpHeight * Time.deltaTime);
        sr.color = tmp;
        StartCoroutine(StopDashing());
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravityScale;
        sr.color = Color.white;
        tr.emitting = false;
        coll.enabled = true;
    }
}