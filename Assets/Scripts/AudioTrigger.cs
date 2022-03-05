/**
* AudioTrigger.cs
* 
* This class contains code for the "AudioTrigger" prefab,
* which triggers a sound once when a sphere collider is triggered.
*/
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[DisallowMultipleComponent]

public class AudioTrigger : MonoBehaviour
{
    [Tooltip("Audio Source to Play on Trigger")]
    [SerializeField] private AudioSource audioSource;

    private SphereCollider sc;

    void Awake()
    {
        sc = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter()
    {
        audioSource.Play();
        sc.enabled = false; // Prevent triggering multiple times.
    }
}
