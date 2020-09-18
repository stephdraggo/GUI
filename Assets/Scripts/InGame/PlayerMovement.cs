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
        public float speed = 5f, jumpSpeed = 8f;
        public Vector3 moveDirection, direction;
        public float smoothTime = 0.1f, smoothVelocity;
        public Transform cam;


        [System.Serializable]
        public struct KeyInputs
        {
            public float horizontal; //horizontal movement value
            public float vertical; //vertical movement value
        }
        public KeyInputs keyInputs;

        void Start()
        {
            controller = gameObject.GetComponent<CharacterController>(); //link the attacher character controller
        }


        void Update()
        {
            if (!PlayerControl.isDead) //if player is alive
            {

                Direction();
                Speed();



                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                if (controller.isGrounded)
                {
                    moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                    moveDirection *= speed;
                    if (Input.GetKey(KeyBind.keys["Jump"])) //if jump key is pressed
                    {
                        moveDirection.y = jumpSpeed; //move up at the rate of jumpSpeed
                    }
                }

                moveDirection.y -= gravity * Time.deltaTime;


                controller.Move(moveDirection * Time.deltaTime);

            }
        }


        /// <summary>Determines what direction to move in based on key inputs from the keys dictionary.</summary>
        void Direction()
        {
            float horizontal = 0; //reset movement values
            float vertical = 0;

            //take key input and check if it matches any of these movement types in the dictionary
            //if a match is found, increase that direction
            if (Input.GetKey(KeyBind.keys["Forward"]))
            {
                vertical++;
            }
            if (Input.GetKey(KeyBind.keys["Backward"]))
            {
                vertical--;
            }
            if (Input.GetKey(KeyBind.keys["Right"]))
            {
                horizontal++;
            }
            if (Input.GetKey(KeyBind.keys["Left"]))
            {
                horizontal--;
            }

            direction = new Vector3(horizontal, 0f, vertical).normalized; //give a vector3 with a magnitude of 1
        }

        /// <summary>Determines the speed to move at based on key inputs.</summary>
        void Speed()
        {
            if (controller.isGrounded) //if player is on the ground
            {

                if (Input.GetKey(KeyBind.keys["Sprint"]) /*&& PlayerControl.canYouRun*/) //if sprint key is pressed
                {
                    speed = 10f;
                }
                else if (Input.GetKey(KeyBind.keys["Crouch"]))
                {
                    speed = 2f;
                }
                else if (Input.anyKey)
                {
                    speed = 5f;
                }
                else
                {
                    speed = 0f;
                }
            }
        }
    }
}