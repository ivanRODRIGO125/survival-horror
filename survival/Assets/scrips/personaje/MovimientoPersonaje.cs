using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(CharacterController))]
public class MovimientoPersonaje : MonoBehaviour
{
    public class FirstPersonController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float mouseSensitivity = 2f;
        public float verticalLookLimit = 80f;
        public float gravity = 9.8f;

        private CharacterController controller;
        private Vector3 moveDirection = Vector3.zero;
        private float verticalVelocity = 0f;
        private float xRotation = 0f;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor
        }

        void Update()
        {
            HandleMovement();
            HandleMouseLook();
        }

        void HandleMovement()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            move = move * moveSpeed;

            // Aplicar gravedad
            if (controller.isGrounded)
            {
                verticalVelocity = -2f; // Empuja ligeramente hacia el suelo para mantener contacto
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            move.y = verticalVelocity;

            controller.Move(move * Time.deltaTime);
        }

        void HandleMouseLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

            Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
