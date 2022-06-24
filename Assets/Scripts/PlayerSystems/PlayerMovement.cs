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

    public Vector2 moveInput;

    [Space(10)]
    [Header("Components")]
    [Tooltip("The Players GFX Sprite Renderer component for the player.")]
    public SpriteRenderer gfx;
    public Animator anim;
    Rigidbody2D playerRigidbody;


    public VariableJoystick vJoystick;

    Vector2 swiper;
    public bool fingerDown;
    public int pixelDetect;
    //if (fingerDown == false && Input.GetMouseButtonDown(0))
    //{
    //    // Debug.Log("touched");
    //    swiper = Input.mousePosition;
    //    fingerDown = true;
    //}

    //mover(Input.mousePosition);

    void Start()
    {
        vJoystick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<VariableJoystick>();
        if(playerRigidbody == null)
            playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            if (vJoystick.Horizontal != 0 || vJoystick.Vertical != 0)
            {
                moveInput.x = vJoystick.Horizontal;
                moveInput.y = vJoystick.Vertical;
            }


            //if ((!fingerDown && Input.GetMouseButtonDown(0)) || fingerDown)
            //{
            //    // Debug.Log("touched");
            //    Debug.Log($"x: {vJoystick.Horizontal}");
            //    Debug.Log($"y: {vJoystick.Vertical}");
            //    fingerDown = true;
            //}
            //if (fingerDown && Input.GetMouseButtonUp(0))
            //{
            //    fingerDown = false;
            //}

        }
    }

    void FixedUpdate()
    {
        if(canMove)
            PlayerMovementInputHandler();
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
    private void PlayerMovementInputHandler()
    {

        MoveAnimHandler();

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

        //if(!Input.GetMouseButtonDown(0))
        //    fingerDown = false;

    }

    void MoveAnimHandler()
    {
        if(moveInput != Vector2.zero)
        {
            anim.SetBool("moving", true);
            if(GetComponent<RyanBeattie.PlayerSystems.Player>().playerType == RyanBeattie.PlayerSystems.PlayerType.Human)
            {
                AudioManager.instance.isWalking = true;
                AudioManager.instance.PlayFootsteps();
            }
        }
        else
        {
            anim.SetBool("moving", false);
            if (GetComponent<RyanBeattie.PlayerSystems.Player>().playerType == RyanBeattie.PlayerSystems.PlayerType.Human)
            {
                AudioManager.instance.isWalking = false;
                AudioManager.instance.PlayFootsteps();
            }
        }
    }
}