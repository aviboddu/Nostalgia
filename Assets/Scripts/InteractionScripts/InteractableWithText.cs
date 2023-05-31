using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DialogueScripts;

/*
Ciel:
Add this script to a game object that is an interactable with subtext
Add multiple lines of subtext to Dialogue field of script in inspector
 */

namespace InteractionScripts
{
    public class InteractableWithText : Interactable
    {
        public Dialogue dialogue;
        private bool _canInteract = true;
        private DialogueManager _dialogueManager;

        private void Start()
        {
            _dialogueManager = FindObjectOfType<DialogueManager>(); // Moved it here for performance reasons
        }

        public override bool CanInteract()
        {
            return _canInteract;
        }

        public override void OnInteract()
        {
            _canInteract = false;
            print("Interacted with " + gameObject.name);

            TriggerDialogue();

            StartCoroutine(ResetInteract(3));
        }

        // This coroutine resets interactions after 'time' seconds.
        // Can use this in any other class if you simply want the interactable to have a recovery period.
        public IEnumerator ResetInteract(float time)
        {
            Debug.Log("Interactable reset in 3 seconds");
            yield return new WaitForSeconds(time);
            Debug.Log("Interactable is reset");
            _canInteract = true;
        }

        public void TriggerDialogue()
        {
            _dialogueManager.StartDialogue(dialogue);
        }
    }
}
