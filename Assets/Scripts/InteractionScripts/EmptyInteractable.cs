using System.Collections;
using UnityEngine;

namespace InteractionScripts
{
    // Basic Test Interactable which prints a message upon interacting. Can interact with it again after a second.
    public class EmptyInteractable : Interactable
    {
        private bool _canInteract = true;
        public override bool CanInteract()
        {
            return _canInteract;
        }

        public override void OnInteract()
        {
            _canInteract = false;
            print("Interacted with " + gameObject.name);
            StartCoroutine(ResetInteract(1));
        }

        // This coroutine resets interactions after 'time' seconds.
        // Can use this in any other class if you simply want the interactable to have a recovery period.
        private IEnumerator ResetInteract(float time)
        {
            yield return new WaitForSeconds(time);
            _canInteract = true;
        }
    }
}
