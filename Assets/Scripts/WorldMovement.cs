using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private float gravityStrength;
    [SerializeField] private bool gravityToRight = true;

    // Don't do what I Want TO CHANGE
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gravityToRight = !gravityToRight;

            if (gravityToRight)
                Physics2D.gravity = new Vector2(gravityStrength, 0);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gravityToRight = !gravityToRight;

            if (gravityToRight)
                Physics2D.gravity = new Vector2(gravityStrength, 0);
        }
    }
}
