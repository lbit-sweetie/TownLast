using UnityEngine;

public class ThirdPirsonControler : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    public Transform cam;

    public float speed = 6f;
    public float boostSpeed = 1.5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;

    public float jumpHeight;
    public float gravity;
    [SerializeField] bool isGrounded;
    Vector3 velicoty;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
        {
            boostSpeed = 1.5f;
            animator.SetBool("run", true);
        }
        else
        {
            boostSpeed = 1;
            animator.SetBool("run", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && !isGrounded)
        {
            boostSpeed = 2.5f;
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.9f);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * boostSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velicoty.y = Mathf.Sqrt((jumpHeight * 10) * -1f * gravity);
        }


        velicoty.y += (gravity * 10) * Time.deltaTime;

        controller.Move(velicoty * Time.deltaTime);
    }

    public void LevelUp(int level)
    {
        jumpHeight *= 3.5f;
    }
}