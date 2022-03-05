/**
* FadeIn.cs
*
* This script creates a fade-from-black effect when the game begins.
*/

using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [Tooltip("Seconds to fade in.")]
    [SerializeField] private float fadeTime;

    private Texture2D fadeTexture;
    private float opacity;
    private bool fading;

    void Start()
    {
        fading = true;
        opacity = 1.0f;

        // Stretch a 1x1 black texture over the screen
        fadeTexture = new Texture2D(1, 1);
        fadeTexture.SetPixel(0, 0, new Color(0,0,0,opacity));
        fadeTexture.Apply();
    }

    void OnGUI(){
        if(fading){
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
    }

    void Update()
    {
        if(fading) {
            // Fade in until opacity of black texture is 0
            if(opacity > 0) {
                opacity -= (1.0f/fadeTime) * Time.deltaTime;
                opacity = Mathf.Max(opacity, 0);
                fadeTexture.SetPixel(0, 0, new Color(0, 0, 0, opacity));
                fadeTexture.Apply();
                return;
            }
            fading = false;
        }
    }
}
