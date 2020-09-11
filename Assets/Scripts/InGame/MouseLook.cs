﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gui
{
    [AddComponentMenu("GUI/Mouse Look")]
    public class MouseLook : MonoBehaviour
    {
        public enum RotationAxis
        {
            MouseH,
            MouseV
        }
        [Header("Rotation Variables")]
        public RotationAxis axis = RotationAxis.MouseH;
        [Range(0, 200)]
        public float sensitivity = 100;
        public float minY = -60, maxY = 60;
        private float _rotY;

        void Start()
        {
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }
            if (GetComponent<Camera>())
            {
                axis = RotationAxis.MouseV;
            }
        }

        #region updateFuntion
        void Update()
        {
            if (!PlayerControl.isDead)
            {
                if (axis == RotationAxis.MouseH)
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0);
                }
                else //MouseV
                {
                    _rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                    _rotY = Mathf.Clamp(_rotY, minY, maxY);
                    transform.localEulerAngles = new Vector3(-_rotY, 0, 0);
                }
            }
        }
        #endregion
    }
}