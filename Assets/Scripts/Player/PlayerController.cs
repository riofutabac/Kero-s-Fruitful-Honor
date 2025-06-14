using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionAsset playerActions;

    [Header("Movement Settings")]
    public int walkSpeed = 50;        // Velocidad de caminar (como tu código original)
    public int runSpeed = 100;        // Velocidad de correr (nueva funcionalidad)
    public float jumpForce = 5f;      // Fuerza del salto

    // Variables privadas para el sistema de Input
    private InputActionMap playerMap;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction runAction;    

    private Vector2 inputMove;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;

    private void Awake()
    {
        playerMap = playerActions.FindActionMap("Player");
        moveAction = playerMap.FindAction("Move");
        jumpAction = playerMap.FindAction("Jump");
        runAction = playerMap.FindAction("Run");  

        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        runAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        runAction.Disable();
    }

    void Update()
    {
        inputMove = moveAction.ReadValue<Vector2>();
        Jump();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        // Determinar si está corriendo (presionando Shift)
        bool isRunning = runAction.IsPressed();

        // Elegir la velocidad correcta
        int currentSpeed = isRunning ? runSpeed : walkSpeed;

        //usar Time.deltaTime para movimiento suave
        playerRb.linearVelocityX = inputMove.x * currentSpeed * Time.deltaTime;

        
        if (inputMove.x == 0)
        {
            playerAnimator.SetBool("walk", false);
        }
        else
        {
            playerAnimator.SetBool("walk", true);
            if (inputMove.x < 0)
            {
                playerSpriteRenderer.flipX = true;
            }
            else
            {
                playerSpriteRenderer.flipX = false;
            }
        }
    }

    void Jump()
    {
        if (jumpAction.WasPressedThisFrame() && FootLogic.isGrounded)
        {
            
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAnimator.SetTrigger("jump");
        }
    }
}