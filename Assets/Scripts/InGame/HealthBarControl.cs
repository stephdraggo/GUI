using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    [AddComponentMenu("GUI/Health Bar Control")]
    public class HealthBarControl : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]
        public Transform cam;
        public Image healthBar;
        public GameObject canvas;
        public Gradient gradient;
        public float currentHealth, maxHealth;
        #endregion

        void Start()
        {
            cam = Camera.main.transform;
        }

        void Update()
        {
            healthBar.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
            healthBar.color = gradient.Evaluate(healthBar.fillAmount);
        }

        private void LateUpdate()
        {
            canvas.transform.LookAt(transform.position + cam.forward);
        }


    }
}