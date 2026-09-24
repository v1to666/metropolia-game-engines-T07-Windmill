using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;

    private float moveSpeed = 10f;
    private float rotateSpeed = 2f;

    private float verticalVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * xMovement + transform.forward * zMovement;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);

        float mouseInput = Input.GetAxis("Mouse X") * rotateSpeed;

        transform.Rotate(0f, mouseInput, 0f);
    }
}