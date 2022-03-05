/**
* Player.cs
*
* This script performs various non-movement related functions.
* For the player game object. This includes various sound effects.
*/

using UnityEngine;

namespace TigerTail.FPSController
{

    [RequireComponent(typeof(CharacterController))]
    [DisallowMultipleComponent]
    public class Player : MonoBehaviour
    {
        [Tooltip("Audio Source")]
        [SerializeField] private AudioSource audioSource;

        [Tooltip("Footstep Audio Sounds (Snow)")]
        [SerializeField] private AudioClip[] snowFootstepSounds;

        [Tooltip("Footstep Audio Sounds (Wood)")]
        [SerializeField] private AudioClip[] woodFootstepSounds;

        [Tooltip("Flashlight Sound")]
        [SerializeField] private AudioClip flashlightSound;

        [Tooltip("The flashlight game object.")]
        [SerializeField] private GameObject flashlight;
        private CharacterController cc;
        private AudioClip[] materialFootstepSet;

        void Start()
        {
            // Have no sound by default.
            materialFootstepSet = snowFootstepSounds;
        }

        void Awake() 
        {
            cc = GetComponent<CharacterController>();
        }

        private void OnControllerColliderHit(ControllerColliderHit other) {
            DetermineStepSoundSet(other);
        }

        private void LateUpdate()
        {
            // Toggle Flashlight on 'F' Keypress
            if(Input.GetKeyDown(KeyCode.F))
            {
                ToggleFlashlight();
            }
            HandleFootsteps();
        }

        // Sets the footstep sound effect set based on the layer stepped on.
        private void DetermineStepSoundSet(ControllerColliderHit other) {
            
            // If on wooden structures use the wood sound effects
            if(LayerIn(1 << other.gameObject.layer, 1 << LayerMask.NameToLayer("Wood"))) {
                materialFootstepSet = woodFootstepSounds;
                return;
            }           
            
            /* If no other material is being walked on,
               default to snow sound effects. */
            materialFootstepSet = snowFootstepSounds;
        }

        // Toggles flashlight and plays click sound
        private void ToggleFlashlight() {
            flashlight.SetActive(!flashlight.activeSelf);
            audioSource.PlayOneShot(flashlightSound);
        }

        // Handles the playing of footstep sound effects
        private void HandleFootsteps() {
            if(
                cc.isGrounded
                && cc.velocity.magnitude >= 1
                && !audioSource.isPlaying
            ) {
                // Choose random sound
                int soundIndex = Random.Range(0, materialFootstepSet.Length);
                audioSource.clip = materialFootstepSet[soundIndex];
                
                // Play the sound, delaying it based on speed of player
                audioSource.PlayDelayed(1/cc.velocity.magnitude);
            }
        }

        // Returns true if layer is one of the layers in the provided bitmask
        private bool LayerIn(int layer, int layerMask) {
            return (layer & layerMask) != 0;
        }
    }
}
