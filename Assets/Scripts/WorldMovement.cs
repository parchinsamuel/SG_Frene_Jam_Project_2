using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private float gravityStrength;
    [SerializeField] private bool gravityToRight = true;
    [SerializeField] Transform playerTransform;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gravityToRight = !gravityToRight;

            if (gravityToRight)
            {
                Physics2D.gravity = new Vector2(gravityStrength, 0);
                playerTransform.Rotate(Vector3.forward, 90);
            }
                
            
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gravityToRight = !gravityToRight;

            if (gravityToRight)
            {
                Physics2D.gravity = new Vector2(-gravityStrength, 0);
                playerTransform.Rotate(Vector3.forward, -90);
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            gravityToRight = !gravityToRight;

            if (gravityToRight)
            {
                Physics2D.gravity = new Vector2(0, gravityStrength);
                playerTransform.Rotate(Vector3.forward, 180);
            }
            
        }
    }
}
