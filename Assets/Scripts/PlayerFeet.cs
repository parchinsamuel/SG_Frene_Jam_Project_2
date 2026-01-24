using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private WorldMovement world;
    [SerializeField] public BoxCollider2D feetCollider;

    public bool isGrounded { get; private set; }

    private int groundContacts;

    private void Update()
    {
        if (!world.isWorldRotating)
        {
            isGrounded = groundContacts > 0;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Ground")) return;
        groundContacts++;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("Ground")) return;
        groundContacts--;
        if (groundContacts < 0)
            groundContacts = 0;
    }

    public void ResetGround()
    {
        groundContacts = 0;
        isGrounded = false;
    }
}
