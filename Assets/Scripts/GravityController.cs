using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravityForce = 25f;

    public float maxGravitySpeed = 8f;

    [SerializeField] private Rigidbody2D player;

    private Vector2 gravityDirection = Vector2.down;

    void Awake()
    {
        player.gravityScale = 0;
    }

    void FixedUpdate()
    {
        ApplyGravity();
        LimitGravitySpeed();
    }

    void ApplyGravity()
    {
        player.AddForce(gravityDirection * gravityForce, ForceMode2D.Force);
    }

    void LimitGravitySpeed()
    {
        Vector2 velocity = player.linearVelocity;

        float gravitySpeed = Vector2.Dot(velocity, gravityDirection);

        if (gravitySpeed > maxGravitySpeed)
        {
            player.linearVelocity -= gravityDirection * (gravitySpeed - maxGravitySpeed);
        }
    }

    // Appelé par un autre script
    public void SetGravity(Vector2 newDirection)
    {
        gravityDirection = newDirection.normalized;
    }
}
