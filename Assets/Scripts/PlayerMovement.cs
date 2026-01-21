using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private PlayerFeet playerFeet;

    [Header("Parameters")]

    [SerializeField] private float speed;
    [SerializeField] private float jumpower;
    [SerializeField] private Vector2 move;
    [SerializeField] private Vector2 jump;

    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    void PlayerMove()
    {
        move = new Vector2(0f, player.linearVelocityY);

        if (Input.GetKey(KeyCode.A))
        {
            move.x -= speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move.x += speed;
        }

        

        player.linearVelocity = transform.InverseTransformDirection(move);
    }

    void PlayerJump()
    {
        //jump = new Vector2(0f, player.linearVelocityY);

        //if (Input.GetKey(KeyCode.Space) && playerFeet.isGrounded)
        //{
        //    CancelVelocity();
        //    var direction = transform.InverseTransformDirection(Vector2.up);
        //    player.AddForce(direction * jumpower, ForceMode2D.Impulse);
        //}
    }

    void CancelVelocity()
    {
        if (playerFeet.isGrounded)
        {
            player.linearVelocityY = 0;
        }
    }
}
