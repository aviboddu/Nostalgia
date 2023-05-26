using System.Collections;
using UnityEngine;
using TMPro;

namespace InteractionScripts
{
    // Basic Test Interactable which prints a message upon interacting. Can interact with it again after a second.
    public class EmptyInteractable : Interactable
    {
        // Ciel: add textmeshpro object and text message
        public string interactionText;
        public TextMeshProUGUI popupTextObject;

        private bool _canInteract = true;

        public override bool CanInteract()
        {
            return _canInteract;
        }

        public new void Awake()
        {
            base.Awake();
            popupTextObject.gameObject.SetActive(false);
        }


        public override void OnInteract()
        {
            _canInteract = false;
            print("Interacted with " + gameObject.name);

            // Ciel:
            // check gameobject name
            // display text based on interacted object
            if (gameObject.name == "SampleInteractable")
            {
                popupTextObject.text = interactionText;
                popupTextObject.gameObject.SetActive(true);
            }

            StartCoroutine(ResetInteract(5));
        }

        // This coroutine resets interactions after 'time' seconds.
        // Can use this in any other class if you simply want the interactable to have a recovery period.
        public IEnumerator ResetInteract(float time) 
        {
            yield return new WaitForSeconds(time);
            _canInteract = true;
            // Ciel:
            // deactivate the pop-up text
            popupTextObject.gameObject.SetActive(false);
        }
    }
}
