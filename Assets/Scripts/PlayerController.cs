using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float jumpForce = 25f;
    public float runningSpeed = 1.5f;
    public Animator animator;

    private Rigidbody2D rb2d;
    private Vector3 startingPosition;

    private void Awake()
    {
        instance = this;
        startingPosition = this.transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void StartGame()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        animator.SetBool("isAlive", true);
        this.transform.position = startingPosition;
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

    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);

        if(PlayerPrefs.GetFloat("highscore", 0) < this.GetDistance())
        {
            PlayerPrefs.SetFloat("highscore", this.GetDistance());
        }
    }

    public float GetDistance()
    {
        float traveledDistance = Vector2.Distance(new Vector2(startingPosition.x, 0), new Vector2(this.transform.position.x, 0));
        return traveledDistance;
    }
}
