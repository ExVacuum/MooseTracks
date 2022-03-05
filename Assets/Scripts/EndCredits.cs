/**
* EndCredits.cs
* 
* This script handles the triggering and presentation
* of the game's end credits.
*/

using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[DisallowMultipleComponent]

public class EndCredits : MonoBehaviour
{
    [Tooltip("TextMeshPro Text to Show Text")]
    [SerializeField] private TextMeshProUGUI creditText;

    [Tooltip("Strings to Show in Credit Sequence")]
    [SerializeField] private string[] credits;

    private SphereCollider sc;

    void Start()
    {
        // Hide text at startup
        creditText.enabled = false;
    }

    void Awake() {
        sc = GetComponent<SphereCollider>();
    }

    // Sphere collider triggering will cause credits to begin.
    void OnTriggerEnter(Collider other) {
        StartCoroutine(PlayCredits());
        sc.enabled = false;
    }

    IEnumerator PlayCredits() {
        // Make Credits Visible
        creditText.enabled = true;
        for(int i = 0; i < credits.Length; i++){
            // Set Credit Text to Next String
            creditText.text = credits[i];
            // Show Each String for 5 Seconds
            yield return new WaitForSecondsRealtime(5);
        }
        // Hide Credits Once Again
        creditText.enabled = false;

        // Hang for 5 More Seconds Before Quitting Game.
        yield return new WaitForSecondsRealtime(5);
        Application.Quit();
    }
}
