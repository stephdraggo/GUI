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

                float distance = 15f;
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
                    #region Shop or chest
                    if (hitInfo.collider.TryGetComponent(out GUI3.Inventories.Shop inv))
                    {
                        //set which shop/chest it is here
                        inv.shopPanel.SetActive(true);

                        FindObjectOfType<PauseControl>().ShowInv();
                    }
                    #endregion
                    #region world item
                    if (hitInfo.collider.TryGetComponent(out GUI3.Inventories.ItemHandler _item))
                    {
                        GetComponent<GUI3.Inventories.Inventory>().AddItem(_item.itemId);
                        Destroy(_item.gameObject);
                    }
                    #endregion
                }


            }
            /*
            #region NPC 
            //and that hits info is tagged NPC
            if (hitInfo.collider.CompareTag("NPC"))
            {
                if (hitInfo.collider.GetComponent<NPCDialogueArray>())
                {
                    NPCDialogueArray character = hitInfo.collider.GetComponent<NPCDialogueArray>();
                    dlgMaster.characterNPCName = character.characterName;
                    dlgMaster.currentDialogue = character.dialogueText;
                    dlgMaster.SetUp();
                    dlgMaster.dialoguePanel.SetActive(true);

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Camera.main.GetComponent<Player.MouseLook>().enabled = false;
                    GetComponent<Player.MouseLook>().enabled = false;

                }
                #region HardCode Dialogue
                //Debug that we hit a NPC    
                Debug.Log("Talk to the NPC");
                //THIS ONE HERE IS FOR DIALOGUE
                if (hitInfo.collider.GetComponent<Dialogue>())
                {
                    hitInfo.collider.GetComponent<Dialogue>().showDlg = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Camera.main.GetComponent<Player.MouseLook>().enabled = false;
                    GetComponent<Player.MouseLook>().enabled = false;
                }

                //THIS ONE HERE IS FOR OptionLinearDialogue
                if (hitInfo.collider.GetComponent<OptionLinearDialogue>())
                {
                    hitInfo.collider.GetComponent<OptionLinearDialogue>().showDlg = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Camera.main.GetComponent<Player.MouseLook>().enabled = false;
                    GetComponent<Player.MouseLook>().enabled = false;
                }

                //THIS ONE HERE IS FOR ApprovalDialogue
                if (hitInfo.collider.GetComponent<ApprovalDialogue>())
                {
                    hitInfo.collider.GetComponent<ApprovalDialogue>().showDlg = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Camera.main.GetComponent<Player.MouseLook>().enabled = false;
                    GetComponent<Player.MouseLook>().enabled = false;
                }
                #endregion
            }
            #endregion
            #region Item
            //and that hits info is tagged Item
            if (hitInfo.collider.CompareTag("Item"))
            {
                //Debug that we hit an Item   
                Debug.Log("Pick Up Item");
                ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                if (handler != null)
                {
                    player.quest.goal.ItemCollected(handler.itemId);
                    handler.OnCollection();
                }
            }
            #endregion

            #region Chest
            if (hitInfo.collider.CompareTag("Chest"))
            {
                Chest chest = hitInfo.transform.GetComponent<Chest>();
                if (chest != null)
                {
                    chest.showChestInv = true;
                    LinearInventory.showInv = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                    LinearInventory.currentChest = chest;
                }
            }
            #endregion
            */
        }
    }
}