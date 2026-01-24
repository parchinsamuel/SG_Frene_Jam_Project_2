using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class WorldMovement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private GameObject World;
    [SerializeField] private PlayerFeet playerFeet;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] public bool isWorldRotating { get; private set; }
    [SerializeField] public float animationTurningWorld;

    private void Update()
    {
        if (isWorldRotating) return;

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

    IEnumerator ChangeGravity(int direction)
    {
        isWorldRotating = true;

        // Désactive le collider des pieds pendant la rotation
        playerFeet.feetCollider.enabled = false;

        playerFeet.ResetGround();

        // Boucle de rotation selon la direction
        if (direction == 0)
        {
            for (int i = 0; i < 90; i++)
            {
                World.transform.RotateAround(transform.position, Vector3.forward, -1);
                yield return new WaitForSeconds(animationTurningWorld);
            }
        }
        else if (direction == 1)
        {
            for (int i = 0; i < 90; i++)
            {
                World.transform.RotateAround(transform.position, Vector3.forward, 1);
                yield return new WaitForSeconds(animationTurningWorld);
            }
        }
        else if (direction == 2)
        {
            for (int i = 0; i < 180; i++)
            {
                World.transform.RotateAround(transform.position, Vector3.forward, 1);
                yield return new WaitForSeconds(animationTurningWorld);
            }
        }

        // Fin de rotation
        isWorldRotating = false;

        // Réactive le collider des pieds et reset les contacts
        playerFeet.feetCollider.enabled = true;
        playerFeet.ResetGround();
        playerMovement.ForceToGround();

        yield return new WaitForFixedUpdate(); // laisse Unity recalculer la physique
    }
}
