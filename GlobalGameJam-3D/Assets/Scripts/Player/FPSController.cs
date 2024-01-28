//Source: https://www.youtube.com/watch?v=qQLvcS9FxnY&ab_channel=AllThingsGameDev
using UnityEngine;

namespace GlobalGameJam
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSController : MonoBehaviour
    {
        public static event System.Action<bool> OnPlayerMoving = delegate { };
        public static event System.Action OnPlayerStopped = delegate { };

        [SerializeField] private Camera playerCamera;
        [SerializeField] private float walkSpeed = 6f;
        [SerializeField] private float runSpeed = 12f;
        [SerializeField] private float jumpPower = 7f;
        [SerializeField] private float gravity = 10f;

        [SerializeField] private float lookSpeed = 2f;
        [SerializeField] private float lookXLimit = 45f;

        private Vector3 moveDirection = Vector3.zero;
        private float rotationX = 0;

        float curSpeedX;
        float curSpeedY;
        float movementDirectionY;

        [SerializeField] private bool canMove = true;

        private CharacterController characterController;

        private AudioSource audioSource;
        private AudioClip runClip;
        private AudioClip walkClip;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            PauseListener.OnGamePauseStateChanged += HandleComponent;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {

            #region Handles Movement
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            // Press Left Shift to run
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            if(curSpeedX != 0f || curSpeedY != 0f)
            {
                audioSource.clip
            }
            else
            {
                Debug.Log("OnPlayerStopped");

                OnPlayerStopped?.Invoke();
            }

            #endregion

            #region Handles Jumping
            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpPower;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            #endregion

            #region Handles Rotation
            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }

            #endregion
        }

        private void OnDestroy()
        {
            PauseListener.OnGamePauseStateChanged -= HandleComponent;
        }

        private void HandleComponent(bool isPaused)
        {
            enabled = !isPaused;
            Cursor.visible = isPaused;
            Cursor.lockState = isPaused ? CursorLockMode.Confined : CursorLockMode.Locked;
        }
    }
}