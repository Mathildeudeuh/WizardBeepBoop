using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask Mask;

    private float direction;

    private Controls controls;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool canJump = false;

    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Main.Reverse.performed += JumpOnperformed;
        controls.Main.LR.performed += MoveLROnperformed;
        controls.Main.LR.canceled += MoveLROncanceled;

    }


    private void MoveLROncanceled(InputAction.CallbackContext obj)
    {
        direction = 0;

    }

    private void MoveLROnperformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<float>();
        spriteRenderer.flipX = (direction < 0);


    }

    private void JumpOnperformed(InputAction.CallbackContext obj)
    {

        if (canJump)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            spriteRenderer.flipY = !spriteRenderer.flipY;
            rigidbody2D.gravityScale = -rigidbody2D.gravityScale;

            animator.SetBool("Jump", true);

        }

    }

    void Start()
    {


        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();


    }


    void Update()
    {

        var hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.001f);

        if (hit.collider != null)
        {
            canJump = true;
            Debug.Log(hit.collider.name);
        }
        else
        {
            canJump = false;
        }
        //if (isOnGround Input.GetButtonDown("Jump"))

       Debug.DrawRay(transform.position, Vector3.down * 5);
    }
    private void FixedUpdate()
    {
        var horizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x);
        if (horizontalSpeed < maxSpeed)
            rigidbody2D.AddForce(new Vector2(speed * direction, 0));
        animator.SetFloat("Speed", horizontalSpeed);
    }

    void OnApplicationQuit()
    {
    }

    private void Sum(int numberLeft, int numberRight)
    {
        var result = numberLeft + numberRight;

    }
}
//Real