using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Platformer : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float jumpForce;
 
    public Animator anim;

    public float fallMultiplier = 2.5f;
    private float oldJumpForce;
    public float lowJumpMultiplier = 2f;

    public bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public int defaultAdditionalJumps = 1;
    int additionalJumps;
    public jetpack jp;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oldJumpForce = jumpForce;
        additionalJumps = defaultAdditionalJumps;
    }

    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //float x = 1;
        float moveBy = x * speed;
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (x < 0)
        {

            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (x != 0)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            additionalJumps--;
            if (jp.ready)
            {
                jp.useFuel();
            }
            else {
                jumpForce = oldJumpForce;
            }

        }
    }

    void BetterJump()
    {

        if (jumpForce > 0)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        else if (jumpForce < 0)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;

            }
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
         
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }


}
