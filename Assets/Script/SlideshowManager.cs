using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlideshowManager : MonoBehaviour
{
    public Sprite[] slides; // Drag and drop your images into this array
    public Image imageDisplay;
    public float slideInterval = 2f;
    public float fadeDuration = 1f;
    public string nextSceneName; // Name of the scene to load after the slideshow

    private int currentSlide = 0;
    private bool isMouseClick = false;

    private void Start()
    {
        // Start the coroutine to handle the slideshow
        StartCoroutine(ShowSlides());
    }

    void Update()
    {
        // Check for mouse left click
        if (Input.GetMouseButtonDown(0))
        {
            isMouseClick = true;
        }
    }

    IEnumerator ShowSlides()
    {
        while (currentSlide < slides.Length)
        {
            isMouseClick = false;

            // Update the image to display the next slide
            imageDisplay.sprite = slides[currentSlide];

            // Fade in the next image
            yield return StartCoroutine(FadeIn(imageDisplay, fadeDuration));

            // Wait for the specified interval before moving to the next slide or check for mouse click
            float timer = 0f;
            while (timer < slideInterval && !isMouseClick)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            // Only fade out if this is not the first image
            if (currentSlide >= 0)
            {
                // Fade out the current image
                yield return StartCoroutine(FadeOut(imageDisplay, fadeDuration));

                // Wait for the fade out to complete
                yield return new WaitForSeconds(fadeDuration);
            }

            // Move to the next slide
            currentSlide++;
        }

        // The slideshow is over, load the next scene
        LoadNextScene();
    }

    IEnumerator FadeOut(Image image, float duration)
    {
        float startAlpha = image.color.a;
        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0f, currentTime / duration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f); // Ensure it's fully faded out
    }

    IEnumerator FadeIn(Image image, float duration)
    {
        float startAlpha = image.color.a;
        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 1f, currentTime / duration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f); // Ensure it's fully faded in
    }

    void LoadNextScene()
    {
        // Load the next scene by name
        SceneManager.LoadScene(0);
    }
}
