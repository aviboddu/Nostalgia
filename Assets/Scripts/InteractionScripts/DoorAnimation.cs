using System;
using System.Collections;
using UnityEngine;

namespace InteractionScripts
{
    public class DoorAnimation : Interactable
    {
        private void Start()
        {
            ObjectiveManager.Manager.ObjectiveChange += AllowInteraction;
        }

        private bool _canInteract;
        public override bool CanInteract()
        {
            return _canInteract;
        }

        public override void OnInteract()
        {
            StartCoroutine(RotateDoor(2f));
            _canInteract = false;
        }

        private void AllowInteraction(int obj)
        {
            if (obj < 6) return;
            ObjectiveManager.Manager.ObjectiveChange -= AllowInteraction;
            _canInteract = true;
        }

        private IEnumerator RotateDoor(float time)
        {
            for (float t = 0; t < time; t += Time.deltaTime)
            {
                gameObject.transform.Rotate(0, Time.deltaTime * 90/time, 0);
                yield return null;
            }
        }
    }
}
