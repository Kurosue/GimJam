using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioClip buttonClickSound;

    private void Start()
    {
        // Find all buttons in the scene
        Button[] buttons = FindObjectsOfType<Button>();

        // Attach the button click sound to each button
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayButtonClickSound);
        }
    }

    private void PlayButtonClickSound()
    {
        // Play the button click sound
        AudioSource.PlayClipAtPoint(buttonClickSound, Camera.main.transform.position);
    }
}