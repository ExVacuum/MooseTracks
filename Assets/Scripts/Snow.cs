/**
* Snow.cs
* 
* This script is used with the Snowfall VFX to keep the
* snow positioned over the head of the player.
*/

using UnityEngine;

public class Snow : MonoBehaviour
{
    [Tooltip("Player object to follow.")]
    [SerializeField] private GameObject player;

    // Offset from VFX graph object to player
    private Vector3 offset;

    void Start()
    {
        // Determine offset at start
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        /* Apply offset to player position to determine 
        where the snowfall object should be. */
        transform.position = player.transform.position + offset;
    }
}
