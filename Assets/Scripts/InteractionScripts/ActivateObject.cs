using UnityEngine;

namespace InteractionScripts
{
    public class ActivateObject : Interactable
    {
        public GameObject objectToActivate;
        public override bool CanInteract()
        {
            return true;
        }

        public override void OnInteract()
        {
            objectToActivate.SetActive(true);
        }
    }
}
