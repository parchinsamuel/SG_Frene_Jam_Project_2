using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    [Header("Parameters")]

    [SerializeField] public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
