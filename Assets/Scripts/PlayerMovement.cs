using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private PlayerFeet playerFeet;
    [SerializeField] private WorldMovement world;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [SerializeField] public bool isrunning;
    [SerializeField] public bool isjumping;
    [SerializeField] public bool isfalling;

    private Vector2 move;

    private void Update()
    {
        if (world.isWorldRotating)
        {
            isjumping = false;
            isrunning = false;
            isfalling = true;
            return;
        }

        PlayerMove();
        PlayerJump();
        UpdateAirState();
    }

    void PlayerMove()
    {
        isrunning = false;

        move = new Vector2(0f, player.linearVelocityY);

        if (Input.GetKey(KeyCode.A))
        {
            move.x -= speed;
            playerSprite.flipX = true;
            isrunning = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += speed;
            playerSprite.flipX = false;
            isrunning = true;
        }

        player.linearVelocity = move;
    }

    void PlayerJump()
    {
        if (Input.GetKey(KeyCode.Space) && playerFeet.isGrounded)
        {
            player.linearVelocityY = 0; // annule la vélocité verticale
            player.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            isjumping = true;
            isfalling = false;
        }
    }


    void UpdateAirState()
    {
        if (!playerFeet.isGrounded)
        {
            if (player.linearVelocityY > 0)
            {
                isjumping = true;
                isfalling = false;
            }
            else
            {
                isjumping = false;
                isfalling = true;
            }
        }
        else
        {
            isjumping = false;
            isfalling = false;
        }
    }

    // Nouvelle fonction pour “poser” le joueur sur le sol après rotation
    public void ForceToGround()
    {
        // Décale légèrement le joueur vers le bas pour toucher le sol
        player.transform.position += Vector3.down * 0.05f;
        playerFeet.ResetGround();
    }
}
