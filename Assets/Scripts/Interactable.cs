using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

// Interactable Abstract Class
// In order to create a custom interaction, simply extend this class and override the appropriate methods.
// Then attach the subclass to the relevant object.
// Note: The relevant object must have collision.
public abstract class Interactable : MonoBehaviour
{
   // This light component will spawn at the origin of the object.
   // If you wish to shift the position, move the mesh accordingly so its origin is in a different place.
   // Potential TODO: Replace this system with an outline effect
   private Light _lightComponent;
   public float lightIntensity = 0.5f; // Light intensity.
   public float fadeTime = 0.5f; // Fade in time in seconds.
   
   private bool _inFocus;
   public void Awake()
   {
      gameObject.layer = 10; // Interactable Layer
      _lightComponent = gameObject.AddComponent<Light>();
      _lightComponent.intensity = 0;
   }

   // Every frame the player has the interact button down, has the interactable selected and CanInteract() == true,
   //       the player will call OnInteract().
   public abstract bool CanInteract();
   
   public abstract void OnInteract();

   // When you look at the interactable
   public void OnFocus()
   {
      float initialIntensity = _lightComponent.intensity;
      if (!_inFocus)
      {
         _inFocus = true;
         StartCoroutine(FadeLight(initialIntensity, lightIntensity, fadeTime));
      }
   }

   // When you look away from the interactable
   public void OnLoseFocus()
   {
      float initialIntensity = _lightComponent.intensity;
      if (_inFocus)
      {
         _inFocus = false;
         StartCoroutine(FadeLight(initialIntensity, 0, fadeTime));
      }
   }

   // This lets the light fade in and out, rather than a binary flip.
   private IEnumerator FadeLight(float initial, float final, float time)
   {
      for (float lerpVal = 0; lerpVal < 1; lerpVal += Time.deltaTime / time)
      {
         _lightComponent.intensity = initial + (final - initial) * lerpVal;
         yield return new WaitForNextFrameUnit();
      }

      _lightComponent.intensity = final;
   }
}
