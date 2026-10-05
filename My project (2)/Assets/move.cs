using UnityEngine;

public class mo : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;

    public KeyCode Spacebar = KeyCode.Space;
    public KeyCode Z = KeyCode.Z;
    public KeyCode X = KeyCode.X;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask whatIsGround;

    private bool grounded;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckGround();

        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (Input.GetKey(Z))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

            if (spriteRenderer != null)
                spriteRenderer.flipX = true;
        }

        if (Input.GetKey(X))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            if (spriteRenderer != null)
                spriteRenderer.flipX = false;
        }
    }

    void CheckGround()
    {
        if (groundCheck == null)
        {
            grounded = false;
            return;
        }

        grounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundDistance,
            whatIsGround
        ) != null;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundDistance
            );
        }
    }
}
