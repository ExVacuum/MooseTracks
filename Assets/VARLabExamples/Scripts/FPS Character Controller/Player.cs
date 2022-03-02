using UnityEngine;

namespace TigerTail.FPSController
{
    [DisallowMultipleComponent]
    public class Player : MonoBehaviour
    {
        [Tooltip("The flashlight game object.")]
        [SerializeField] private GameObject flashlight;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                flashlight.SetActive(!flashlight.activeSelf);
            }
        }

    }
}
