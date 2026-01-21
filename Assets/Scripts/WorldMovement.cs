using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private float gravityStrength;
    [SerializeField] private bool gravityChange = true;
    [SerializeField] Transform playerTransform;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gravityChange = !gravityChange;

            if (gravityChange)
            {
                Physics2D.gravity = new Vector2(gravityStrength, 0);
                playerTransform.Rotate(Vector3.forward, 90);
            }
                
            
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gravityChange = !gravityChange;

            if (gravityChange)
            {
                Physics2D.gravity = new Vector2(-gravityStrength, 0);
                playerTransform.Rotate(Vector3.forward, -90);
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            gravityChange = !gravityChange;

            if (gravityChange)
            {
                Physics2D.gravity = new Vector2(0, gravityStrength);
                playerTransform.Rotate(Vector3.forward, 180);
            }
            
        }
    }
}
