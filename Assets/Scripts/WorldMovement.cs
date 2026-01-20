using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Transform centreRotation;
    [SerializeField] private Rigidbody2D gravityRb;

    [Header("Parameters")]

    [SerializeField] private float rotateGravityUp;
    [SerializeField] private float rotateGravityRight;
    [SerializeField] private float rotateGravityLeft;

    void Update()
    {
        
    }

    void ApplyNewGravity()
    {
        Vector2 direction = (centreRotation.position - transform.position).normalized;
        
    }
}
