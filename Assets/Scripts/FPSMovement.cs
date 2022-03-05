/**
* FPSMovement.cs
* 
* This script contains an implementation of first-person movement using
* the Unity CharacterController component, which allows
* trivial handling of grounding, as well as slope and step management.
*/
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
            // Determine Movement in the XZ plane base on player input axes
            Vector3 movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            movement *= moveSpeed; // Scale XZ input by the movement speed factor
            
            // Player Velocity
            velocity.x = movement.x;
            /* Apply gravitational acceleration to the Y velocity.
               Account for framerate when applying acceleration force. */
            velocity.y += Physics.gravity.y * Time.deltaTime;
            velocity.z = movement.z;
            
            /* Apply velocity to controller.
               Account for framerate. */
            cc.Move(velocity * Time.deltaTime);
            
            // Reset fall speed once grounded.
            if(cc.isGrounded)
            {
                velocity.y = 0;
            }
        }
    }
}
