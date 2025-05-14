using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Movimiento : MonoBehaviour
{
        public float moveSpeed = 5f;
        public float mouseSensitivity = 2f;
        public float gravity = 9.81f;

        private CharacterController controller;
        private Transform cam;
        private float verticalVelocity;
        private float cameraPitch = 0f;

        void Start()
        {
            controller = GetComponent<CharacterController>();// iguala la variable controller al CharacterController del dueño del script(basicamente el jugador)
            cam = Camera.main.transform;//iguala la variable cam a la camara principal,por eso el .main
            Cursor.lockState = CursorLockMode.Locked;//bloquea el mouse al iniciar
        }

        void Update()
        {
            MovePlayer();
            LookAround();
        }

        void MovePlayer()
        {
            // Movimiento lateral y frontal
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            move *= moveSpeed;

            // Gravedad simple
            if (controller.isGrounded)
            {
                verticalVelocity = -1f; // Empuja al suelo
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            move.y = verticalVelocity;

            controller.Move(move * Time.deltaTime);
        }

        void LookAround()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Rotar horizontalmente el jugador
            transform.Rotate(Vector3.up * mouseX);

            // Rotar verticalmente la cámara
            cameraPitch -= mouseY;
            cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f);//el movimiento en vertical de la camara no puede excederse de esos valores.
            cam.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
        }
    }

