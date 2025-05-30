using UnityEngine;

public class Chicken : Enemy
{
    [SerializeField] private EnemyData data;
    [SerializeField] private LayerMask groundLayer;

    private float speed = 2f;
    private Rigidbody2D rb;
    private bool movingRight = false;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2((movingRight ? 1 : -1) * speed, rb.linearVelocity.y);

        Vector3 rayOrigin = transform.position + Vector3.down * 0.5f + Vector3.right * (movingRight ? 0.5f : -0.5f);
        RaycastHit2D groundInfo = Physics2D.Raycast(rayOrigin, Vector2.down, 1f, groundLayer);

        if (groundInfo.collider == null)
            Flip();
    }

    private void Flip()
    {
        movingRight = !movingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public override int GetDamage()
    {
        return data != null ? data.damage : 0;
    }
}
