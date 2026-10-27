using UnityEngine;
using UnityEngine.InputSystem;

public class character_controller : MonoBehaviour
{
    private MyActions controls;
    private Vector2 moveInput;

    private void Awake()
    {
        // Initialize the generated PlayerControls class.
        controls = new MyActions();
    }

    private void OnEnable()
    {
        // Enable the Player action map.
        controls.CharacterController.Enable();
        // Subscribe to the Move action's performed and canceled events.
        controls.CharacterController.Movement.performed += OnMove;
        controls.CharacterController.Movement.canceled += OnMove;
    }

    private void OnDisable()
    {
        // Unsubscribe and disable the action map.
        controls.CharacterController.Movement.performed -= OnMove;
        controls.CharacterController.Movement.canceled -= OnMove;
        controls.CharacterController.Disable();
    }

    // This method gets called whenever the "Move" action value changes.
    private void OnMove(InputAction.CallbackContext context)
    {
        // Read the Vector2 value from the action.
        moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        // Use the moveInput vector to update player movement.
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(movement * Time.deltaTime * 5f);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        // Ignore if no Rigidbody or it's kinematic
        if (rb == null || rb.isKinematic) return;

        // Only push horizontally (ignore y) if this desired
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Apply force
        float pushForce = 2f;
        rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
    }

}
