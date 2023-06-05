using UnityEngine;
namespace InteractionScripts
{
    public class ModifyObject : Interactable
    {
        public GameObject objectToModify;
        public Transform newTransform;
        public Interactable[] newInteractions;
        private InteractableContainer _interactableContainer;

        private void Start()
        {
            _interactableContainer = objectToModify.GetComponent<InteractableContainer>();
        }

        public override bool CanInteract()
        {
            return true;
        }

        public override void OnInteract()
        {
            objectToModify.transform.position = newTransform.position;
            objectToModify.transform.rotation = newTransform.rotation;
            objectToModify.transform.localScale = newTransform.localScale;
            _interactableContainer.interactables = newInteractions;
        }
    }
}
