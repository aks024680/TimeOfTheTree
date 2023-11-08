using UnityEngine;

namespace tott
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5.0f;
        [SerializeField, Range(0.1f, 1500), Header("跳躍力道")]
        private float jumpForce = 500f;
        private float currentJumpForce = 0f;  // 新增一個變數來跟踪當前的跳躍力道

        [SerializeField, Range(0.1f, 10), Header("跳躍速度減緩因子")]
        private float jumpDampingFactor = 1.5f;
        public Transform cameraTransform;
        public LayerMask groundLayer;

        private CharacterController characterController;
        public Vector3 moveDirection;
        private bool isGrounded;

        public float MoveSpeed = 3f;

        

        Animator animator;
        private string jumpTrigger;

        private void Start()
        {
            
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            MoveAndFlip();
            IsGrounded();
        }
        private void FixedUpdate()
        {
            
            
        }
        private void MoveAndFlip()
        {
            // Check if the player is on the ground
            isGrounded = Physics.CheckSphere(transform.position, 0f, groundLayer);

            // Get input for player movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate move direction relative to camera
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0.0f;
            right.y = 0.0f;
            forward.Normalize();
            right.Normalize();
            moveDirection = forward * verticalInput + right * horizontalInput;

            // Apply movement
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            

            // Apply gravity
            moveDirection.y -= 9.81f;

            // Apply final movement
            characterController.Move(moveDirection * Time.deltaTime);
        }
        private void Jump()
        {
            //animator.SetTrigger("JumpTrigger");

            //currentJumpForce = currentJumpForce * jumpDampingFactor * Time.deltaTime;  // 跳躍力道減緩
            //Vector3 jumpVector = Vector3.up * currentJumpForce * Time.deltaTime;
            //print(jumpVector);

            Vector3 jumpVector = Vector3.up * 100 ;
            characterController.Move(jumpVector);
        }
        public void IsGrounded()
        {
            if (characterController.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
                else
                {
                    animator.SetBool("isGrounded",true);
                }
            }
            else
            {
                animator.SetBool("isGrounded", false);
            }
            
        }
    }



}


