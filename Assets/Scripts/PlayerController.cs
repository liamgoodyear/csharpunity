using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 25f;
    public float runningSpeed = 1.5f;
    private Rigidbody2D rb2d;
    public Animator animator;

    private void Awake()
    {
        animator.SetBool("isAlive", true);
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            animator.SetBool("isGrounded", IsGrounded());
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (rb2d.velocity.x < runningSpeed)
            {
                rb2d.velocity = new Vector2(runningSpeed, rb2d.velocity.y);
            }
        }
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public LayerMask groundLayer;

    bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
        }
        else
        {          
            return false;
        }
    }
}
