
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TigerTail.FPSController
{
    [RequireComponent(typeof(CharacterController))]
    [DisallowMultipleComponent]
    public class FPSMovement : MonoBehaviour
    {
        [Tooltip("Player Movement Speed (m/s)")]
        [SerializeField] private float moveSpeed = 1;

        private CharacterController cc;
        private Vector3 velocity;

        private void Awake()
        {
            cc = GetComponent<CharacterController>();
        }

        private void Update() {
            Vector3 movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            movement *= moveSpeed;
            velocity.x = movement.x;
            velocity.y += Physics.gravity.y * Time.deltaTime;
            velocity.z = movement.z;
            cc.Move(velocity * Time.deltaTime);
            if(cc.isGrounded)
            {
                velocity.y = 0;
            }
        }
    }
}
