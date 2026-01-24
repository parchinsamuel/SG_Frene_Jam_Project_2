using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private PlayerFeet playerFeet;

    [Header("Parameters")]

    [SerializeField] private float speed;
    [SerializeField] private float jumpower;
    [SerializeField] private Vector2 move;
    [SerializeField] private Vector2 jump;

    [HideInInspector] public bool isrunning;
    [HideInInspector] public bool isjumping;
    [HideInInspector] public bool isfalling;
    void Update()
    {
        PlayerMove();
        PlayerJump();
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
        isjumping = false;

        jump = new Vector2(0f, player.linearVelocityY);

        if (Input.GetKey(KeyCode.Space) && playerFeet.isGrounded)
        {
            CancelVelocity();
            var direction = transform.InverseTransformDirection(Vector2.up);
            player.AddForce(direction * jumpower, ForceMode2D.Impulse);

            isjumping = true;
            isfalling = false;
        }
    }

    void CancelVelocity()
    {
        if (playerFeet.isGrounded)
        {
            player.linearVelocityY = 0;
        }
    }
}
