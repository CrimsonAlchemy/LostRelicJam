using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    [Tooltip("The speed at which the player will be moving.")]
    [Range(1, 15)] public float moveSpeed;
    public bool canMove = true;

    Vector2 moveInput;

    [Space(10)]
    [Header("Components")]
    [Tooltip("The Players GFX Sprite Renderer component for the player.")]
    public SpriteRenderer gfx;
    Rigidbody2D playerRigidbody;

    void Start()
    {
        if(playerRigidbody == null)
            playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        if(canMove)
            PlayerMovementInputHandler();
    }
    private void PlayerMovementInputHandler()
    {
        if (moveInput.x > 0)
        {
            gameObject.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            //bodySR.flipX = true;
        }

        if (moveInput.x < 0)
        {
            gameObject.GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
            //bodySR.flipX = false;

        }

        moveInput.Normalize();
        playerRigidbody.velocity = moveInput * moveSpeed;

    }
}