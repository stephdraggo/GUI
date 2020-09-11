using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gui
{
    [AddComponentMenu("GUI/Player Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Physics")]
        public CharacterController controller;
        public float gravity = 20f;
        [Header("Movement Variables")]
        public float speed = 5f;
        public float jumpSpeed = 8f;
        public Vector3 moveDirection;
        public KeyCode forward, left, right, backward, jump, sprint, crouch;
        [System.Serializable]
        public struct KeyInputs
        {
            public float horizontal;
            public float vertical;
        }
        public KeyInputs keyInputs;

        void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
        }


        void Update()
        {
            keyInputs.horizontal = 0;
            keyInputs.vertical = 0;
            if (Input.GetKey(KeyBind.keys["Forward"]))
            {
                keyInputs.vertical++;
            }
            if (Input.GetKey(KeyBind.keys["Backward"]))
            {
                keyInputs.vertical--;
            }
            if (Input.GetKey(KeyBind.keys["Right"]))
            {
                keyInputs.horizontal++;
            }
            if (Input.GetKey(KeyBind.keys["Left"]))
            {
                keyInputs.horizontal--;
            }
            if (!PlayerControl.isDead)
            {
                if (controller.isGrounded)
                {
                    moveDirection = transform.TransformDirection(new Vector3(keyInputs.horizontal, 0, keyInputs.vertical));
                    moveDirection *= speed;
                    if (Input.GetKey(KeyBind.keys["Jump"]))
                    {
                        moveDirection.y = jumpSpeed;
                    }
                    if (Input.GetKey(KeyBind.keys["Sprint"]) && speed != 10/* && PlayerControl.canYouRun*/)
                    {
                        speed = 10f;
                    }
                    else if (Input.GetKey(KeyBind.keys["Crouch"]) && speed != 2)
                    {
                        speed = 2f;
                    }
                    else
                    {
                        speed = 5f;
                    }
                }
                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);

            }
        }
    }
}