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
                float hori = Input.GetAxisRaw("Horizontal");
                float vert = Input.GetAxisRaw("Vertical");
                Vector3 direction = new Vector3(hori, 0, vert);

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
                transform.rotation = Quaternion.Euler(0, targetAngle, 0);

                Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                controller.Move(moveDirection * Time.deltaTime * speed);

                #region code that works and is commented out
                /*
                Direction(); //determine direction
                Speed(); //determine speed
                
                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);
                */
                #endregion
            }
        }

        #region code that works and is commented out

        /*
        /// <summary>Determines what direction to move in based on key inputs from the keys dictionary.</summary>
        void Direction()
        {
            keyInputs.horizontal = 0; //reset movement values
            keyInputs.vertical = 0;

            //take key input and check if it matches any of these movement types in the dictionary
            //if a match is found, increase that direction
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
        }

        /// <summary>Determines the speed to move at based on key inputs.</summary>
        void Speed()
        {
            if (controller.isGrounded) //if player is on the ground
            {
                moveDirection = transform.TransformDirection(new Vector3(keyInputs.horizontal, 0, keyInputs.vertical)); //the direction is given by the Direction function
                moveDirection *= speed; //direction multiplied by speed for movement
                if (Input.GetKey(KeyBind.keys["Jump"])) //if jump key is pressed
                {
                    moveDirection.y = jumpSpeed; //move up at the rate of jumpSpeed
                }
                if (Input.GetKey(KeyBind.keys["Sprint"]) && PlayerControl.canYouRun) //if sprint key is pressed
                {
                    speed = 10f;
                }
                else if (Input.GetKey(KeyBind.keys["Crouch"]))
                {
                    speed = 2f;
                }
                else
                {
                    speed = 5f;
                }
            }
        }*/
        #endregion
    }
}