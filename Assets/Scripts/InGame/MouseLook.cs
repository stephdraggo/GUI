using UnityEngine;

namespace GUI1
{
    [AddComponentMenu("GUI/Mouse Look")]
    public class MouseLook : MonoBehaviour
    {
        #region Variables
        public enum RotationAxis
        {
            MouseH,
            MouseV
        }
        [Header("Rotation Variables")]
        [SerializeField,Range(0, 200)]
        private float sensitivity = 100;

        private RotationAxis axis = RotationAxis.MouseH;
        private float _minY = -60, _maxY = 60;
        private float _rotY;
        #endregion
        #region Start
        void Start()
        {
            if (GetComponent<Rigidbody>()) //if there is a rigidbody attached (if player)
            {
                GetComponent<Rigidbody>().freezeRotation = true; //make it turn with the player movement
            }
            if (GetComponent<Camera>()) //if there is a camera attached (if not player)
            {
                axis = RotationAxis.MouseV; //set to opposite axis
            }
        }
        #endregion
        #region Update
        void Update()
        {
            if (!PlayerControl.isDead) //if player is alive
            {
                if (axis == RotationAxis.MouseH) //if this is the player
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0); //rotate player on the y axis (x coordinate) according to mouse input
                }
                else //if this is the camera
                {
                    _rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; //calculate the amount to rotate on the x axis (y coordinate) according to mouse input and sensitivity
                    _rotY = Mathf.Clamp(_rotY, _minY, _maxY); //clamp value to prevent looking upside down
                    transform.localEulerAngles = new Vector3(-_rotY, 0, 0); //rotate camera according to calculations
                }
            }
        }
        #endregion
    }
}