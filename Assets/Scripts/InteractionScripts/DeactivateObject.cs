using UnityEngine;

namespace InteractionScripts
{
    public class DeactivateObject : Interactable
    {
        public GameObject objectToDeactivate;
        public override bool CanInteract()
        {
            return true;
        }

        public override void OnInteract()
        {
            objectToDeactivate.SetActive(false);
        }
    }
}