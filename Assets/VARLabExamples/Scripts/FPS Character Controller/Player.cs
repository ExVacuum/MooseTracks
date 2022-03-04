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

        // Start is called before the first frame update
        void Start()
        {
            cc = GetComponent<CharacterController>();
            materialFootstepSet = new AudioClip[0];
        }

        private void OnControllerColliderHit(ControllerColliderHit other) {
            if(other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
                materialFootstepSet = snowFootstepSounds;
                return;
            }
            if(other.gameObject.layer == LayerMask.NameToLayer("Wood")) {
                materialFootstepSet = woodFootstepSounds;
                return;
            }
        }

        private void LateUpdate()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                flashlight.SetActive(!flashlight.activeSelf);
                audioSource.PlayOneShot(flashlightSound);
            }
            if(
                cc.isGrounded
                && cc.velocity.magnitude >= 1
                && !audioSource.isPlaying
            ) {
                int soundIndex = Random.Range(0, materialFootstepSet.Length);
                audioSource.clip = materialFootstepSet[soundIndex];
                audioSource.PlayDelayed(1/cc.velocity.magnitude);
            }
        }

    }
}
