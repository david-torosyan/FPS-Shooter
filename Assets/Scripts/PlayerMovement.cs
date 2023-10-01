using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f * 2;
    public float jumbHeigth = 3f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool IsMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        // Resetting ground velocity 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Getting the inputes
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Creating the moving vector
        Vector3 move = transform.right * x + transform.forward * y;

        // Moving the player 
        controller.Move(move * speed * Time.deltaTime);

        // Check if player can jump
        if (Input.GetButton("Jump") && isGrounded)
        {
            // Going up 
            velocity.y = Mathf.Sqrt(jumbHeigth * -2f * gravity);
        }

        // Falling down
        velocity.y += gravity * Time.deltaTime;

        // Executing the jump 
        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            IsMoving = true;
            //TODO: For later use
        }
        else
        {
            IsMoving = false;
        }
        lastPosition = gameObject.transform.position;

    }
}
