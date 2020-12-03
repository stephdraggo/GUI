using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI1
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
                Interact();

                    float oldGravity = moveDirection.y;

                Direction();
                Speed();

                //transform.rotation = Quaternion.Euler(0f, angle, 0f);
                //moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * moveDirection; //changing this to up instead of forward makes him jump only
                moveDirection = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * moveDirection;

                float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref smoothVelocity, smoothTime);
                transform.eulerAngles = new Vector3(0f, smoothAngle, 0f);

                moveDirection.x *= speed;
                moveDirection.y = oldGravity;
                moveDirection.z *= speed;

                if (controller.isGrounded)
                {
                    
                    //moveDirection *= speed;
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

            moveDirection = new Vector3(horizontal, 0f, vertical).normalized; //give a vector3 with a magnitude of 1
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

        void Interact()
        {
            if (Input.GetKeyDown(KeyBind.keys["Interact"]))
            {
                Ray ray;
                RaycastHit hitInfo;

                ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

                float distance = 5f;
                int layerMask = LayerMask.NameToLayer("Interactable"); //get layer number
                layerMask = 1 << layerMask; //bit shift to get actual number
                if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
                {
                    #region NPC
                    if (hitInfo.collider.TryGetComponent(out GameSystems.NPCs.BaseNPC npc))
                    {
                        npc.Interact();
                    }
                    #endregion
                }


            }
        }
    }
}