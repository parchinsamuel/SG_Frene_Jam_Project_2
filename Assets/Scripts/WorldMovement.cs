using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class WorldMovement : MonoBehaviour
{
    [Header("Parameters")]

    [Serialize] public GameObject World;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(ChangeGravity(0));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(ChangeGravity(1));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(ChangeGravity(2));
        }
    }

    public float animationTurningWorld;
    IEnumerator ChangeGravity(int direction)
    {
        if (direction == 0)
        {
            for ( float i = 0; i < 90 ; i++)
            {
                yield return new WaitForSeconds(animationTurningWorld);
                World.transform.RotateAround(transform.position, new Vector3(0, 0, 1), -1);
                print (i);
            }
        }
        else if (direction == 1)
        {
            for (int i = 0; i < 90; i++)
            {
                yield return new WaitForSeconds(animationTurningWorld);
                World.transform.RotateAround(transform.position, new Vector3(0, 0, 1), 1);
            }
        }
        else if (direction == 2)
        {
            for (int i = 0; i < 180; i++)
            {
                yield return new WaitForSeconds(animationTurningWorld * 2);
                World.transform.RotateAround(transform.position, new Vector3(0, 0, 1), 1);
            }
        }
    }
}
