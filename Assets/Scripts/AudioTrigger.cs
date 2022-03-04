using System.Collections;
using System.Collections.Generic;
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
        sc.enabled = false;
    }
}
