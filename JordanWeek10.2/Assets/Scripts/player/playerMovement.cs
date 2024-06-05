using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    [Header("Transforms")]
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;
    [SerializeField] Transform focalPoint;
    

    public Vector3 offset;

    [Header("Speeds")]
    [SerializeField] float speed = 6f;
    [SerializeField] float sprintSpeed = 12f;
    [SerializeField] float jumpHeight;
    float fakeGrav = 9.81f;

    Vector3 velocity;
    [SerializeField] float gravity = -9.81f;

    [Header("Character Rotation Speed")]
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelocity;
    bool isSprinting;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Sprint();
        Jump();
        
        
    }
        
        void PlayerMove()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            // Set camera look at position
            focalPoint.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);





            if (direction.magnitude >= 0.1f)
            {

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
                direction = transform.TransformDirection(moveDir);
            }
        }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 6f;
        }
    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Move(Vector3.up * jumpHeight * Time.deltaTime);
        }
        
    }
}



