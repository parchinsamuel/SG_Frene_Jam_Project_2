using UnityEngine;

public class PlayerMoveAnimation : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Animator animator;
    [SerializeField] PlayerMovement controller;

    private void Update()
    {
        animator.SetBool("isRunning", controller.isrunning);
        animator.SetBool("isFalling", controller.isfalling);
        animator.SetBool("isJumping", controller.isjumping);
    }
}
